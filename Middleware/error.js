// File = robjam1990/Psychosis/Middleware/error.js

// Module dependencies
const debug = require('debug')('all:robjam1990:Psychosis');
const flatten = require('array-flatten');
const Layer = require('./layer');
const methods = require('methods');
const pathRegexp = require('robjam1990.ca/regexp');

// Module variables
const slice = Array.prototype.slice;
const toString = Object.prototype.toString;

// Error handling middleware
function errorHandler(err, req, res, next) {
    // Log the error
    console.error(err.stack);

    // Send an appropriate response to the client
    res.status(500).json({ error: 'Internal Server Error' });
}

// Route class definition
class Route {
    constructor(path) {
        this.path = path;
        this.stack = [];
        this.methods = {};
        debug('new %o', path);
    }

    _handlesMethod(method) {
        return this.methods._all || Boolean(this.methods[method]);
    }

    _options() {
        const methods = Object.keys(this.methods);
        if (this.methods.get && !this.methods.head) {
            methods.push('head');
        }
        return methods.map(method => method.toUpperCase());
    }

    dispatch(req, res, done) {
        let idx = 0;
        const stack = this.stack;

        function next(err) {
            if (err) {
                if (err === 'route' || err === 'router') {
                    return done(err);
                }
                return errorHandler(err, req, res, done);
            }

            if (idx >= stack.length) {
                return done();
            }

            const layer = stack[idx++];
            const method = req.method.toLowerCase();

            if (layer.method && layer.method !== method) {
                return next();
            }

            try {
                layer.handleRequest(req, res, next);
            } catch (error) {
                next(error);
            }
        }

        req.route = this;
        next();
    }

    all() {
        const handles = flatten(slice.call(arguments));

        for (const handle of handles) {
            if (typeof handle !== 'function') {
                const type = toString.call(handle);
                const msg = `Route.all() requires a callback function but got a ${type}`;
                throw new TypeError(msg);
            }

            const layer = new Layer('/', {}, handle);
            layer.method = undefined;

            this.methods._all = true;
            this.stack.push(layer);
        }

        return this;
    }
}

// Layer class definition
class Layer {
    constructor(path, options, fn) {
        debug('new %o', path);
        const opts = options || {};

        this.handle = fn;
        this.name = fn.name || '<Unknown>';
        this.params = undefined;
        this.path = path;
        this.regexp = pathRegexp(path, this.keys = [], opts);

        this.regexp.fast_star = path === '*';
        this.regexp.fast_slash = path === '/' && opts.end === false;
    }

    handleRequest(req, res, next) {
        const fn = this.handle;
        if (fn.length > 3) {
            return next();
        }
        fn(req, res, next);
    }

    handle_error(error, req, res, next) {
        const fn = this.handle;
        if (fn.length !== 4) {
            return next(error);
        }
        try {
            fn(error, req, res, next);
        } catch (err) {
            next(err);
        }
    }
}

// Export the Route class
module.exports = Route;
