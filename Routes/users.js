// File: robjam1990/Psychosis/Routes/users.js

const express = require('express');
const router = express.Router();
const { body, validationResult } = require('express-validator');
const bcrypt = require('bcrypt');
const User = require('../models/User'); // Assuming you have a User model

// POST /users/register
router.post('/register', [
    // Input validation
    body('username')
        .isLength({ min: 3 }).withMessage('Username must be at least 3 characters long')
        .trim()
        .escape(),
    body('email')
        .isEmail().withMessage('Invalid email address')
        .normalizeEmail(),
    body('password')
        .isLength({ min: 6 }).withMessage('Password must be at least 6 characters long')
        .trim(),
], async (req, res) => {
    try {
        // Check for validation errors
        const errors = validationResult(req);
        if (!errors.isEmpty()) {
            return res.status(400).json({ errors: errors.array() });
        }

        // Check if the user already exists
        const existingUser = await User.findOne({ email: req.body.email });
        if (existingUser) {
            return res.status(400).json({ error: 'User with this email already exists.' });
        }

        // Hash the password
        const saltRounds = 10;
        const hashedPassword = await bcrypt.hash(req.body.password, saltRounds);

        // Create a new user object
        const newUser = new User({
            username: req.body.username,
            email: req.body.email,
            password: hashedPassword
        });

        // Save the user to the database
        const savedUser = await newUser.save();

        // Optionally send a verification email here

        // Respond with success message
        res.status(201).json({ message: 'User registered successfully', user: savedUser });
    } catch (error) {
        console.error('Error registering user:', error);
        res.status(500).json({ error: 'An unexpected error occurred. Please try again later.' });
    }
});

module.exports = router;
