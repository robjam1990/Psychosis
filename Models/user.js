// File = robjam1990/Psychosis/Models/user.js
const express = require('express');
const { body, param, validationResult } = require('express-validator');
const router = express.Router();

// Sample data for demonstration
const users = [
    { id: 1, name: 'John Doe' },
    { id: 2, name: 'Jane Smith' },
    { id: 3, name: 'Bob Johnson' }
];

// Middleware for error handling
const handleValidationErrors = (req, res, next) => {
    const errors = validationResult(req);
    if (!errors.isEmpty()) {
        return res.status(400).json({ errors: errors.array() });
    }
    next();
};

// Middleware for authentication (dummy implementation)
const authenticateUser = (req, res, next) => {
    // Dummy check for authentication (replace with actual implementation)
    const isAuthenticated = true; // Example: Check if user is authenticated
    if (!isAuthenticated) {
        return res.status(401).json({ error: 'Unauthorized' });
    }
    next();
};

// Define user routes
router.get('/', authenticateUser, (req, res) => {
    res.json(users);
});

router.get('/:id', authenticateUser, [
    param('id').isInt().withMessage('ID must be an integer')
], handleValidationErrors, (req, res) => {
    const id = parseInt(req.params.id);
    const user = users.find(user => user.id === id);
    if (!user) {
        return res.status(404).json({ error: 'User not found' });
    }
    res.json(user);
});

module.exports = router;
