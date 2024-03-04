from flask import Flask, json
from flask import request
from flask import jsonify

# Importing routes
from routes.index import indexRoutes
from routes.users import userRoutes

# Importing middleware
from middleware.auth import authMiddleware
from middleware.errorHandlers import errorHandlers

# Importing custom logger middleware
from middleware.logger import loggerMiddleware

app = Flask(__name__)

# Applying middleware for parsing JSON bodies
app.before_request(json.jsonify)

# Applying custom logger middleware
app.before_request(loggerMiddleware)

# Applying middleware for authentication
app.before_request(authMiddleware)

# Assigning routes
app.register_blueprint(indexRoutes)
app.register_blueprint(userRoutes, url_prefix='/users')

# Implementing error handling middleware
app.register_error_handler(404, errorHandlers)

# Starting the server
PORT = int(os.environ.get('PORT', 3000))
if __name__ == '__main__':
    app.run(host='0.0.0.0', port=PORT)
