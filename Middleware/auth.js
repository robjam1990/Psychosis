const fs = require('fs');
const bcrypt = require('bcrypt');
const { promisify } = require('util');
const re = /[!@#$%^&*(),.?":{}|<>]/;

class User {
    constructor(username, password) {
        this.username = username;
        this.password = password;
    }
}

async function loadUsers() {
    try {
        const readFile = promisify(fs.readFile);
        const userData = await readFile('users.json', 'utf8');
        return JSON.parse(userData).map(user => new User(user.username, user.password));
    } catch (error) {
        if (error.code === 'ENOENT' || error instanceof SyntaxError) {
            return [];
        }
        throw error;
    }
}

async function saveUsers(users) {
    const usersData = users.map(user => ({ username: user.username, password: user.password }));
    await fs.promises.writeFile('users.json', JSON.stringify(usersData, null, 4), 'utf8');
}

function hashPassword(password) {
    const salt = bcrypt.genSaltSync();
    return bcrypt.hashSync(password, salt);
}

function validatePassword(password) {
    // Password strength requirements
    if (password.length < 8) {
        return false;
    }
    if (!/[A-Z]/.test(password)) {
        return false;
    }
    if (!/[a-z]/.test(password)) {
        return false;
    }
    if (!/[0-9]/.test(password)) {
        return false;
    }
    if (!re.test(password)) {
        return false;
    }
    return true;
}

async function registerUser(username, password) {
    const users = await loadUsers();
    if (users.some(user => user.username === username)) {
        console.log("Username already exists. Please choose a different one.");
        return false;
    }

    if (!validatePassword(password)) {
        console.log("Password does not meet the requirements.");
        return false;
    }

    const hashedPassword = hashPassword(password);
    const newUser = new User(username, hashedPassword);
    users.push(newUser);
    await saveUsers(users);
    console.log("Registration successful.");
    return true;
}

function verifyPassword(inputPassword, hashedPassword) {
    return bcrypt.compareSync(inputPassword, hashedPassword);
}

async function loginUser(username, password) {
    const users = await loadUsers();
    const user = users.find(user => user.username === username && verifyPassword(password, user.password));
    if (user) {
        console.log("Login successful.");
        return true;
    }
    console.log("Invalid username or password. Please try again.");
    return false;
}

// Additional functions for session management, password reset, etc. can be added here

// Example usage:
// registerUser('exampleUser', 'StrongPassword123');
// loginUser('exampleUser', 'StrongPassword123');
