// routes/about.js
const express = require('express');
const router = express.Router();

router.use((req, res, next) => {
    // Middleware logic here
    next();
});

router.get('/', (req, res) => {
    res.send('About page');
});

router.post('/', (req, res) => {
    // Logic for handling POST requests to the about page
    res.send('About page (POST)');
});

router.put('/', (req, res) => {
    // Logic for handling PUT requests to the about page
    res.send('About page (PUT)');
});

module.exports = router;
