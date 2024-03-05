const express = require('express');
const { body, validationResult } = require('express-validator');
const bcrypt = require('bcrypt');
const User = require('../models/User'); // Assuming you have a User model
const nodemailer = require('nodemailer');
const router = express.Router();
const winston = require('winston'); // Import Winston for logging

// Middleware to check if user is authenticated
const isAuthenticated = (req, res, next) => {
    if (req.isAuthenticated()) {
        next();
    } else {
        res.status(401).json({ error: 'Unauthorized' });
    }
};

// Logger setup
const logger = winston.createLogger({
    level: 'info',
    format: winston.format.json(),
    transports: [
        new winston.transports.File({ filename: 'error.log', level: 'error' }),
        new winston.transports.File({ filename: 'combined.log' })
    ]
});

// GET /users/profile
router.get('/profile', isAuthenticated, (req, res) => {
    // Return user profile data
    res.json({ user: req.user });
});

// PUT /users/profile
router.put('/profile', isAuthenticated, async (req, res) => {
    try {
        // Update user profile data
        const updatedUser = await User.findByIdAndUpdate(req.user._id, req.body, { new: true });
        res.json({ message: 'Profile updated successfully', user: updatedUser });
    } catch (error) {
        logger.error('Error updating profile:', error); // Log error
        res.status(500).json({ error: 'An unexpected error occurred. Please try again later.' });
    }
});

// PATCH /users/profile
router.patch('/profile', isAuthenticated, async (req, res) => {
    try {
        // Partially update user profile data
        const updatedUser = await User.findByIdAndUpdate(req.user._id, req.body, { new: true });
        res.json({ message: 'Profile updated successfully', user: updatedUser });
    } catch (error) {
        logger.error('Error updating profile:', error); // Log error
        res.status(500).json({ error: 'An unexpected error occurred. Please try again later.' });
    }
});

// DELETE /users/profile
router.delete('/profile', isAuthenticated, async (req, res) => {
    try {
        // Delete user profile
        await User.findByIdAndDelete(req.user._id);
        res.json({ message: 'Profile deleted successfully' });
    } catch (error) {
        logger.error('Error deleting profile:', error); // Log error
        res.status(500).json({ error: 'An unexpected error occurred. Please try again later.' });
    }
});

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

        // Send verification email
        const transporter = nodemailer.createTransport({
            service: 'gmail',
            auth: {
                user: 'your-email@gmail.com',
                pass: 'your-password'
            }
        });

        const mailOptions = {
            from: 'your-email@gmail.com',
            to: savedUser.email,
            subject: 'Account Verification',
            text: 'Please verify your account by clicking on the following link: https://example.com/verify'
        };

        transporter.sendMail(mailOptions, (error, info) => {
            if (error) {
                logger.error('Error sending verification email:', error); // Log error
                res.status(500).json({ error: 'An unexpected error occurred. Please try again later.' });
            } else {
                logger.info('Verification email sent:', info.response); // Log success
                res.status(201).json({ message: 'User registered successfully', user: savedUser });
            }
        });
    } catch (error) {
        logger.error('Error registering user:', error); // Log error
        res.status(500).json({ error: 'An unexpected error occurred. Please try again later.' });
    }
});

// POST /users/login
router.post('/login', (req, res) => {
    // Implement login logic here
});

// POST /users/logout
router.post('/logout', (req, res) => {
    // Implement logout logic here
});

// POST /users/forgot-password
router.post('/forgot-password', (req, res) => {
    // Implement forgot password logic here
});

// POST /users/reset-password
router.post('/reset-password', (req, res) => {
    // Implement reset password logic here
});

// POST /users/verify
router.post('/verify', (req, res) => {
    // Implement account verification logic here
});

module.exports = router;
