# File: robjam1990/Psychosis/Middleware/error.py

# Module dependencies
import logging
import re

# Module variables
logger = logging.getLogger('all:robjam1990:Psychosis')


# Error handling middleware
def error_handler(err, req, res, next):
    # Log the error
    logger.error(err)

    # Send an appropriate response to the client
    res.status(500).json({'error': 'Internal Server Error'})


# Route class definition
class Route:
    def __init__(self, path):
        self.path = path
        self.stack = []
        self.methods = {}
        logger.debug('new %s', path)

    def _handles_method(self, method):
        return self.methods['_all'] or bool(self.methods[method])

    def _options(self):
        methods = list(self.methods.keys())
        if 'get' in methods and 'head' not in methods:
            methods.append('head')
        return [method.upper() for method in methods]

    def dispatch(self, req, res, done):
        idx = 0
        stack = self.stack

        def next(err=None):
            nonlocal idx
            if err:
                if err == 'route' or err == 'router':
                    return done(err)
                return error_handler(err, req, res, done)

            if idx >= len(stack):
                return done()

            layer = stack[idx]
            method = req.method.lower()

            if layer.method and layer.method != method:
                return next()

            try:
                layer.handle_request(req, res, next)
            except Exception as error:
                next(error)

        req.route = self
        next()

    def all(self, *handles):
        handles = [item for sublist in handles for item in sublist]

        for handle in handles:
            if not callable(handle):
                raise TypeError(f"Route.all() requires a callback function but got a {type(handle)}")

            layer = Layer('/', {}, handle)
            layer.method = None

            self.methods['_all'] = True
            self.stack.append(layer)

        return self


# Layer class definition
class Layer:
    def __init__(self, path, options, fn):
        logger.debug('new %s', path)
        opts = options or {}

        self.handle = fn
        self.name = fn.__name__ if hasattr(fn, '__name__') else '<Unknown>'
        self.params = None
        self.path = path
        self.regexp, self.keys = path_regexp(path, opts)

        self.regexp['fast_star'] = path == '*'
        self.regexp['fast_slash'] = path == '/' and opts.get('end', False)

    def handle_request(self, req, res, next):
        fn = self.handle
        if len(fn.__code__.co_varnames) > 3:
            return next()
        fn(req, res, next)

    def handle_error(self, error, req, res, next):
        fn = self.handle
        if len(fn.__code__.co_varnames) != 4:
            return next(error)
        try:
            fn(error, req, res, next)
        except Exception as err:
            next(err)


# Utility function to parse path regular expression
def path_regexp(path, options):
    keys = []
    regexp = re.compile(path, **options)
    return regexp, keys
