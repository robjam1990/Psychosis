from flask import Blueprint, request, jsonify
from flask_jwt_extended import jwt_required, get_jwt_identity
from flask_expects_json import expects_json
from werkzeug.security import generate_password_hash, check_password_hash
from models import User, db
import jwt
import datetime

auth_bp = Blueprint('auth', __name__)

@auth_bp.route('/users/profile', methods=['GET'])
@jwt_required()
def get_profile():
    current_user = get_jwt_identity()
    user = User.query.filter_by(email=current_user).first()
    if not user:
        return jsonify({'error': 'User not found'}), 404
    return jsonify({'user': user.serialize()}), 200

@auth_bp.route('/users/profile', methods=['PUT'])
@jwt_required()
@expects_json({
    'type': 'object',
    'properties': {
        'username': {'type': 'string'},
        'email': {'type': 'string', 'format': 'email'},
        'password': {'type': 'string', 'minLength': 6}
    },
    'required': ['username', 'email', 'password']
})
def update_profile():
    current_user = get_jwt_identity()
    user = User.query.filter_by(email=current_user).first()
    if not user:
        return jsonify({'error': 'User not found'}), 404
    data = request.json
    user.username = data['username']
    user.email = data['email']
    user.password = generate_password_hash(data['password'])
    db.session.commit()
    return jsonify({'message': 'Profile updated successfully', 'user': user.serialize()}), 200

@auth_bp.route('/users/profile', methods=['DELETE'])
@jwt_required()
def delete_profile():
    current_user = get_jwt_identity()
    user = User.query.filter_by(email=current_user).first()
    if not user:
        return jsonify({'error': 'User not found'}), 404
    db.session.delete(user)
    db.session.commit()
    return jsonify({'message': 'Profile deleted successfully'}), 200

@auth_bp.route('/users/register', methods=['POST'])
@expects_json({
    'type': 'object',
    'properties': {
        'username': {'type': 'string'},
        'email': {'type': 'string', 'format': 'email'},
        'password': {'type': 'string', 'minLength': 6}
    },
    'required': ['username', 'email', 'password']
})
def register():
    data = request.json
    username = data['username']
    email = data['email']
    password = data['password']

    user = User.query.filter_by(email=email).first()
    if user:
        return jsonify({'error': 'User with this email already exists'}), 400

    new_user = User(username=username, email=email, password=generate_password_hash(password))
    db.session.add(new_user)
    db.session.commit()

    token = jwt.encode({'user': email, 'exp': datetime.datetime.utcnow() + datetime.timedelta(minutes=30)}, 'secret_key')
    return jsonify({'message': 'User registered successfully', 'token': token}), 201

@auth_bp.route('/users/login', methods=['POST'])
@expects_json({
    'type': 'object',
    'properties': {
        'email': {'type': 'string', 'format': 'email'},
        'password': {'type': 'string'}
    },
    'required': ['email', 'password']
})
def login():
    data = request.json
    email = data['email']
    password = data['password']

    user = User.query.filter_by(email=email).first()
    if not user or not check_password_hash(user.password, password):
        return jsonify({'error': 'Invalid email or password'}), 401

    token = jwt.encode({'user': email, 'exp': datetime.datetime.utcnow() + datetime.timedelta(minutes=30)}, 'secret_key')
    return jsonify({'message': 'Login successful', 'token': token}), 200

@auth_bp.route('/users/logout', methods=['POST'])
@jwt_required()
def logout():
    return jsonify({'message': 'Logout successful'}), 200

@auth_bp.route('/users/forgot-password', methods=['POST'])
def forgot_password():
    # Implement forgot password logic here
    pass

@auth_bp.route('/users/reset-password', methods=['POST'])
def reset_password():
    # Implement reset password logic here
    pass

@auth_bp.route('/users/verify', methods=['POST'])
def verify():
    # Implement account verification logic here
    pass
