// routes/index.js
const express = require('express');
const bodyParser = require('body-parser');
const { body, validationResult } = require('express-validator');

const router = express.Router();

// Middleware
router.use(bodyParser.urlencoded({ extended: false }));
router.use(bodyParser.json());

// Global validation middleware
router.use([
    body('username').isEmail().withMessage('Invalid email'),
    body('password').isLength({ min: 5 }).withMessage('Password must be at least 5 characters long'),
]);

router.use((req, res, next) => {
    console.log('Custom middleware');
    next();
});

// Routes
router.use('/', require('./about'));
router.use('/contact', require('./contact'));
router.use('/products', require('./products'));

router.get('/', (req, res) => {
    res.send('Welcome to the main index');
});

router.post('/example', (req, res) => {
    const errors = validationResult(req);
    if (!errors.isEmpty()) {
        return res.status(400).json({ errors: errors.array() });
    }
    res.send('Valid input');
});
// errorHandling.js
module.exports = function (err, req, res, next) {
    console.error(err.stack);
    res.status(500).send('Internal Server Error');
};

module.exports = router;
