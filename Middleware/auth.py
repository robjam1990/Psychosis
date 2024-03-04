# file = robjam1990/psychosis/middleware/auth.py
import json
import bcrypt
import re

class User:
    def __init__(self, username, password):
        self.username = username
        self.password = password

def load_users():
    try:
        with open('users.json', 'r') as file:
            users_data = json.load(file)
    except FileNotFoundError:
        return []
    except json.JSONDecodeError:
        return []
    return [User(user['username'], user['password']) for user in users_data]

def save_users(users):
    users_data = [{'username': user.username, 'password': user.password} for user in users]
    with open('users.json', 'w') as file:
        json.dump(users_data, file)

def hash_password(password):
    salt = bcrypt.gensalt()
    hashed_password = bcrypt.hashpw(password.encode('utf-8'), salt)
    return hashed_password.decode('utf-8')

def validate_password(password):
    # Password strength requirements
    if len(password) < 8:
        return False
    if not re.search(r'[A-Z]', password):
        return False
    if not re.search(r'[a-z]', password):
        return False
    if not re.search(r'[0-9]', password):
        return False
    if not re.search(r'[!@#$%^&*(),.?":{}|<>]', password):
        return False
    return True

def register_user(username, password):
    users = load_users()
    if any(user.username == username for user in users):
        print("Username already exists. Please choose a different one.")
        return False

    if not validate_password(password):
        print("Password does not meet the requirements.")
        return False

    hashed_password = hash_password(password)
    new_user = User(username, hashed_password)
    users.append(new_user)
    save_users(users)
    print("Registration successful.")
    return True

def verify_password(input_password, hashed_password):
    return bcrypt.checkpw(input_password.encode('utf-8'), hashed_password.encode('utf-8'))

def login_user(username, password):
    users = load_users()
    for user in users:
        if user.username == username and verify_password(password, user.password):
            print("Login successful.")
            return True
    print("Invalid username or password. Please try again.")
    return False

# Additional functions for session management, password reset, etc. can be added here
