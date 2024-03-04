using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

namespace Psychosis.Gameplay.Games
{
    public class Bot
    {
        private readonly string _server;
        private readonly string _port;
        private readonly Dictionary<string, string> _options;
        private readonly string _gameId;
        private readonly string _playerId;
        private readonly string _credentials;
        private readonly int _numPlayers;
        private HubConnection _connection;

        public Bot(string server = "localhost", string port = "8000", Dictionary<string, string> options = null)
        {
            _server = server;
            _port = port;
            _options = options ?? new Dictionary<string, string>();
            _gameId = $"{_options.GetValueOrDefault("game_name", "default")}:{_options.GetValueOrDefault("game_id", "default")}";
            _playerId = _options.GetValueOrDefault("player_id", "1");
            _credentials = _options.GetValueOrDefault("credentials", "default");
            _numPlayers = int.Parse(_options.GetValueOrDefault("num_players", "2"));

            _connection = new HubConnectionBuilder()
                .WithUrl($"http://{_server}:{_port}")
                .ConfigureLogging(logging =>
                {
                    logging.SetMinimumLevel(LogLevel.Information);
                })
                .Build();

            _connection.On<string, Dictionary<string, object>>("Update", (gameId, state) =>
            {
                var stateId = state.ContainsKey("_stateID") ? state["_stateID"].ToString() : null;
                var ctx = state.ContainsKey("ctx") ? (Dictionary<string, object>)state["ctx"] : null;

                if (stateId == null || ctx == null)
                {
                    Console.WriteLine($"Received incomplete game state: {state}");
                    return;
                }

                if (gameId == _gameId)
                {
                    // Handle game state update
                    Console.WriteLine($"Received updated game state: {state}");

                    if (ctx.ContainsKey("gameover"))
                    {
                        GameOver(state["G"], ctx);
                    }
                    else if (((List<string>)ctx.GetValueOrDefault("actionPlayers", new List<string>())).Contains(_playerId))
                    {
                        Console.WriteLine($"Current game phase: {ctx.GetValueOrDefault("phase")}");
                        var actions = Think(state["G"], ctx);
                        if (!(actions is List<object>))
                        {
                            actions = new List<object> { actions };
                        }
                        foreach (var action in (List<object>)actions)
                        {
                            Console.WriteLine($"Sending action: {((Dictionary<string, object>)action).GetValueOrDefault("payload")}");
                            _connection.SendAsync("Update", action, stateId, gameId, _playerId);
                        }
                    }
                }
            });

            _connection.Closed += async (error) =>
            {
                Console.WriteLine("Connection closed...");
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await _connection.StartAsync();
            };
        }

        public async Task StartAsync()
        {
            try
            {
                await _connection.StartAsync();
                Console.WriteLine("Connected to server");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to server: {ex.Message}");
            }
        }

        public Dictionary<string, object> MakeMove(string type, params string[] args)
        {
            return CreateAction("MAKE_MOVE", type, args);
        }

        public Dictionary<string, object> GameEvent(string type)
        {
            return CreateAction("GAME_EVENT", type);
        }

        protected virtual Dictionary<string, object> CreateAction(string action, string type, string[] args = null)
        {
            args = args ?? new string[] { };
            return new Dictionary<string, object>
            {
                ["type"] = action,
                ["payload"] = new Dictionary<string, object>
                {
                    ["type"] = type,
                    ["args"] = args,
                    ["playerID"] = _playerId,
                    ["credentials"] = _credentials
                }
            };
        }

        protected virtual object Think(object G, Dictionary<string, object> ctx)
        {
            throw new NotImplementedException("Method 'Think' must be implemented in a subclass");
        }

        protected virtual object GameOver(object G, Dictionary<string, object> ctx)
        {
            throw new NotImplementedException("Method 'GameOver' must be implemented in a subclass");
        }
    }

    public class MyBot : Bot
    {
        public MyBot(string server = "localhost", string port = "8000", Dictionary<string, string> options = null)
            : base(server, port, options)
        {
        }

        protected override object Think(object G, Dictionary<string, object> ctx)
        {
            // Example: Bot always makes the same move
            return MakeMove("MOVE_TYPE", "arg1", "arg2");
        }

        protected override object GameOver(object G, Dictionary<string, object> ctx)
        {
            Console.WriteLine($"Game over. Final state: {G}");
            return null;
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            // Initialize and run the bot
            var myBot = new MyBot();
            await myBot.StartAsync();

            Console.WriteLine("Press Ctrl+C to exit...");
            while (true)
            {
                await Task.Delay(1000);
            }
        }
    }
}
