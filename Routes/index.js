// File = robjam1990/Psychosis/Routes/index.js
const express = require('express');
const router = express.Router();
const { validationResult } = require('express-validator');

// Define index route
router.get('/', (req, res) => {
    res.send('Welcome to the main index');
});

// Example of input validation middleware
router.post('/example', [
    body('username').isEmail(),
    body('password').isLength({ min: 5 }),
], (req, res) => {
    const errors = validationResult(req);
    if (!errors.isEmpty()) {
        return res.status(400).json({ errors: errors.array() });
    }
    // Process valid input
    res.send('Valid input');
});

module.exports = router;
