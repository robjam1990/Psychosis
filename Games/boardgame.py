# File = robjam1990/Psychosis/Gameplay/Games/boardgame.py
import logging
import socketio

logging.basicConfig(level=logging.INFO)
log = logging.getLogger('psychosis_bot')

class Namespace(socketio.ClientNamespace):

    def __init__(self, bot, *args, **kwargs):
        super().__init__(*args, **kwargs)
        self.bot = bot
        self.previous_state_id = None

    def on_connect(self):
        log.info('Connected to server')

    def on_disconnect(self):
        log.info('Disconnected from server')

    def on_reconnect(self):
        log.info('Reconnected to server')

    def on_update(self, game_id, state):
        state_id = state.get('_stateID')
        ctx = state.get('ctx')

        if not (state_id and ctx):
            log.warning("Received incomplete game state: %s", state)
            return

        if game_id == self.bot.game_id:
            if not self.previous_state_id or state_id >= self.previous_state_id:
                self.previous_state_id = state_id
                log.debug('Received updated game state: %s', state)
                if 'gameover' in ctx:
                    self.bot.gameover(state['G'], ctx)
                elif self.bot.player_id in ctx.get('actionPlayers', []):
                    log.info('Current game phase: %s', ctx.get('phase'))
                    actions = self.bot.think(state['G'], ctx)
                    if not isinstance(actions, list):
                        actions = [actions]
                    for action in actions:
                        log.info('Sending action: %s', action.get('payload'))
                        self.emit('update', action, state_id, game_id, self.bot.player_id)

class Bot:

    def __init__(self, server='localhost', port='8000', options=None):
        opts = {
            'game_name': 'default',
            'game_id': 'default',
            'player_id': '1',
            'credentials': 'default',
            'num_players': 2
        }
        opts.update(options or {})
        self.game_id = f"{opts['game_name']}:{opts['game_id']}"
        self.player_id = opts['player_id']
        self.credentials = opts['credentials']
        self.num_players = opts['num_players']

        self.sio = socketio.Client()
        self.sio.register_namespace(Namespace(self))
        self.sio.connect(f"http://{server}:{port}")

    def _create_action(self, action, typ, args=None):
        args = args or []
        return {
            'type': action,
            'payload': {
                'type': typ,
                'args': args,
                'playerID': self.player_id,
                'credentials': self.credentials
            }
        }

    def make_move(self, typ, *args):
        return self._create_action('MAKE_MOVE', typ, list(args))

    def game_event(self, typ):
        return self._create_action('GAME_EVENT', typ)

    def think(self, _G, _ctx):
        raise NotImplementedError("Method 'think' must be implemented in a subclass")

    def gameover(self, _G, _ctx):
        raise NotImplementedError("Method 'gameover' must be implemented in a subclass")

    def listen(self, timeout=1):
        try:
            self.sio.wait(seconds=timeout)
        except KeyboardInterrupt:
            log.info("KeyboardInterrupt received. Exiting...")
        except Exception as e:
            log.exception("An error occurred while listening for updates: %s", e)


if __name__ == "__main__":
    # Example subclass implementation of Bot
    class MyBot(Bot):

        def think(self, _G, _ctx):
            # Example: Bot always makes the same move
            return self.make_move('MOVE_TYPE', 'arg1', 'arg2')

        def gameover(self, _G, _ctx):
            log.info("Game over. Final state: %s", _G)

    # Initialize and run the bot
    my_bot = MyBot()
    my_bot.listen()
