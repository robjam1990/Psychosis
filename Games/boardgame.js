const io = require("socket.io-client");
const { EventEmitter } = require("events");

const log = console;

class Namespace extends EventEmitter {
    constructor(bot, ...args) {
        super(...args);
        this.bot = bot;
        this.previousStateId = null;
    }

    onConnect() {
        log.info('Connected to server');
    }

    onDisconnect() {
        log.info('Disconnected from server');
    }

    onReconnect() {
        log.info('Reconnected to server');
    }

    onUpdate(gameId, state) {
        const stateId = state._stateID;
        const ctx = state.ctx;

        if (!(stateId && ctx)) {
            log.warning("Received incomplete game state: ", state);
            return;
        }

        if (gameId === this.bot.gameId) {
            if (!this.previousStateId || stateId >= this.previousStateId) {
                this.previousStateId = stateId;
                log.debug('Received updated game state: ', state);
                if ('gameover' in ctx) {
                    this.bot.gameover(state.G, ctx);
                } else if (ctx.actionPlayers.includes(this.bot.playerId)) {
                    log.info('Current game phase: ', ctx.phase);
                    const actions = this.bot.think(state.G, ctx);
                    if (!Array.isArray(actions)) {
                        actions = [actions];
                    }
                    for (const action of actions) {
                        log.info('Sending action: ', action.payload);
                        this.emit('update', action, stateId, gameId, this.bot.playerId);
                    }
                }
            }
        }
    }
}

class Bot {
    constructor(server = 'localhost', port = '8000', options = null) {
        const opts = {
            game_name: 'default',
            game_id: 'default',
            player_id: '1',
            credentials: 'default',
            num_players: 2
        };
        Object.assign(opts, options || {});
        this.gameId = `${opts.game_name}:${opts.game_id}`;
        this.playerId = opts.player_id;
        this.credentials = opts.credentials;
        this.numPlayers = opts.num_players;

        this.sio = io.connect(`http://${server}:${port}`);
        this.namespace = new Namespace(this);
        this.sio.on('connect', () => this.namespace.onConnect());
        this.sio.on('disconnect', () => this.namespace.onDisconnect());
        this.sio.on('reconnect', () => this.namespace.onReconnect());
        this.sio.on('update', (gameId, state) => this.namespace.onUpdate(gameId, state));
    }

    _createAction(action, typ, args = []) {
        return {
            type: action,
            payload: {
                type: typ,
                args: args,
                playerID: this.playerId,
                credentials: this.credentials
            }
        };
    }

    makeMove(typ, ...args) {
        return this._createAction('MAKE_MOVE', typ, args);
    }

    gameEvent(typ) {
        return this._createAction('GAME_EVENT', typ);
    }

    think(_G, _ctx) {
        throw new Error("Method 'think' must be implemented in a subclass");
    }

    gameover(_G, _ctx) {
        throw new Error("Method 'gameover' must be implemented in a subclass");
    }

    listen(timeout = 1) {
        try {
            this.sio.connect();
        } catch (error) {
            if (error instanceof KeyboardInterrupt) {
                log.info("KeyboardInterrupt received. Exiting...");
            } else {
                log.exception("An error occurred while listening for updates: ", error);
            }
        }
    }
}

if (require.main === module) {
    // Example subclass implementation of Bot
    class MyBot extends Bot {
        think(_G, _ctx) {
            // Example: Bot always makes the same move
            return this.makeMove('MOVE_TYPE', 'arg1', 'arg2');
        }

        gameover(_G, _ctx) {
            log.info("Game over. Final state: ", _G);
        }
    }

    // Initialize and run the bot
    const myBot = new MyBot();
    myBot.listen();
}
