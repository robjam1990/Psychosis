from flask import Flask, jsonify, request
from flask_validator import ValidateString, ValidateLength, ValidationError

app = Flask(__name__)

# Define index route
@app.route('/', methods=['GET'])
def index():
    return 'Welcome to the main index'

# Example of input validation middleware
@app.route('/example', methods=['POST'])
@ValidateString(key='username', rules=[{'type': 'email'}])
@ValidateLength(key='password', min_length=5)
def example():
    try:
        # Process valid input
        return 'Valid input'
    except ValidationError as e:
        return jsonify({'errors': e.errors}), 400

if __name__ == '__main__':
    app.run(debug=True)
