# File: robjam1990/Psychosis/Routes/users.py

from flask import Blueprint, request, jsonify
from flask_validator import ValidateRequest
from werkzeug.security import generate_password_hash, check_password_hash
from .models import User  # Assuming you have a User model

users_bp = Blueprint('users', __name__)

# POST /users/register
@users_bp.route('/register', methods=['POST'])
@ValidateRequest.validate(
    username={'type': 'string', 'min': 3, 'required': True},
    email={'type': 'string', 'required': True},
    password={'type': 'string', 'min': 6, 'required': True}
)
def register_user():
    try:
        # Check if the user already exists
        existing_user = User.query.filter_by(email=request.json['email']).first()
        if existing_user:
            return jsonify({'error': 'User with this email already exists.'}), 400

        # Hash the password
        hashed_password = generate_password_hash(request.json['password'])

        # Create a new user object
        new_user = User(
            username=request.json['username'],
            email=request.json['email'],
            password=hashed_password
        )

        # Save the user to the database
        new_user.save()

        # Optionally send a verification email here

        # Respond with success message
        return jsonify({'message': 'User registered successfully', 'user': new_user.serialize}), 201
    except Exception as e:
        print('Error registering user:', e)
        return jsonify({'error': 'An unexpected error occurred. Please try again later.'}), 500
