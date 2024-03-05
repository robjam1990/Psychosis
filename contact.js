// Import necessary libraries
const express = require('express');
const router = express.Router();
const nodemailer = require('nodemailer'); // For sending emails
const db = require('../models'); // Assuming you have a database model

// POST route for handling contact form submission
router.post('/', async (req, res) => {
    try {
        // Access form data using req.body
        const { name, email, message } = req.body;

        // Perform necessary operations (e.g. send email, save to database)
        // For example, send email using nodemailer
        const transporter = nodemailer.createTransport({
            // Configure your email transport here
        });

        await transporter.sendMail({
            from: 'your-email@example.com',
            to: 'recipient@example.com',
            subject: 'New Contact Form Submission',
            text: `Name: ${name}\nEmail: ${email}\nMessage: ${message}`,
        });

        // Save form data to the database
        await db.ContactForm.create({
            name,
            email,
            message,
        });

        // Send appropriate response to the client
        res.redirect('/contact/success');
    } catch (error) {
        // If an error occurs, redirect to the error page
        console.error('Error submitting contact form:', error);
        res.redirect('/contact/error');
    }
});

// POST route for handling contact form submission with different URL
router.post('/submit', async (req, res) => {
    try {
        // Access form data using req.body
        const { name, email, message } = req.body;

        // Perform necessary operations (e.g. send email, save to database)
        // For example, send email using nodemailer
        const transporter = nodemailer.createTransport({
            // Configure your email transport here
        });

        await transporter.sendMail({
            from: 'your-email@example.com',
            to: 'recipient@example.com',
            subject: 'New Contact Form Submission',
            text: `Name: ${name}\nEmail: ${email}\nMessage: ${message}`,
        });

        // Save form data to the database
        await db.ContactForm.create({
            name,
            email,
            message,
        });

        // Send appropriate response to the client
        res.redirect('/contact/success');
    } catch (error) {
        // If an error occurs, redirect to the error page
        console.error('Error submitting contact form:', error);
        res.redirect('/contact/error');
    }
});

module.exports = router;
