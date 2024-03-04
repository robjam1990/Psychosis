// Importing Express module and necessary middleware
const express = require('express');
const { json } = require('express');
const { body, validationResult } = require('express');

// Importing routes
const indexRoutes = require('./routes/index');
const userRoutes = require('./routes/users');

// Importing middleware
const authMiddleware = require('./middleware/auth');
const bodyParser = require('body-parser');
const app = express();


// Parse URL-encoded bodies (as sent by HTML forms)
app.use(bodyParser.urlencoded({ extended: true }));

// Parse JSON bodies (as sent by API clients)
app.use(bodyParser.json());

// Define routes
app.use('/', indexRoutes);
app.use('/users', userRoutes);

// Middleware for authentication
app.use(authMiddleware);

// Handle POST request to submit_signup endpoint
app.post('/submit_signup', (req, res) => {
    const { username, email, password } = req.body;

    // Implement your signup logic here (e.g., save user data to database)
    // For simplicity, let's just log the received data for now
    console.log('Received signup data:', { username, email, password });

    // Send a response to the client
    res.send('Signup successful!');
});

// Start the server
const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}`);
});
