from flask import Flask, request, jsonify
from flask_validator import Validate

app = Flask(__name__)

# Global validation middleware
@app.before_request
def global_validation():
    Validate(request, [
        {"username": {"type": "email", "message": "Invalid email"}},
        {"password": {"type": "string", "min": 5, "message": "Password must be at least 5 characters long"}}
    ])

@app.before_request
def custom_middleware():
    print('Custom middleware')

# Routes
@app.route('/')
def main_index():
    return 'Welcome to the main index'

@app.route('/example', methods=['POST'])
def example():
    errors = Validate(request).errors
    if errors:
        return jsonify({"errors": errors}), 400
    return 'Valid input'

# Error handling
@app.errorhandler(500)
def internal_server_error(e):
    print(e)
    return 'Internal Server Error', 500

if __name__ == '__main__':
    app.run(debug=True)
