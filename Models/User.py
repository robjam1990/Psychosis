from flask import Flask, jsonify, request
from flask_validator import ValidateInteger, validate_param, validate_body

app = Flask(__name__)

# Sample data for demonstration
users = [
    {'id': 1, 'name': 'John Doe'},
    {'id': 2, 'name': 'Jane Smith'},
    {'id': 3, 'name': 'Bob Johnson'}
]

# Middleware for error handling
@app.errorhandler(400)
def handle_validation_errors(error):
    return jsonify(errors=error.description['errors']), 400

# Middleware for authentication (dummy implementation)
def authenticate_user():
    # Dummy check for authentication (replace with actual implementation)
    is_authenticated = True  # Example: Check if user is authenticated
    if not is_authenticated:
        return jsonify(error='Unauthorized'), 401

# Define user routes
@app.route('/users', methods=['GET'])
def get_users():
    # Dummy authentication
    auth_result = authenticate_user()
    if auth_result:
        return auth_result
    return jsonify(users)

@app.route('/users/<int:id>', methods=['GET'])
@validate_param('id', ValidateInteger(message='ID must be an integer'))
def get_user_by_id(id):
    # Dummy authentication
    auth_result = authenticate_user()
    if auth_result:
        return auth_result
    user = next((user for user in users if user['id'] == id), None)
    if not user:
        return jsonify(error='User not found'), 404
    return jsonify(user)

if __name__ == '__main__':
    app.run(debug=True)
