# Import necessary libraries
from flask import Blueprint, request, redirect, url_for
import smtplib
from email.mime.text import MIMEText
from email.mime.multipart import MIMEMultipart
from .models import db  # Assuming you have a database model

# Define a Blueprint for the contact form routes
contact_bp = Blueprint('contact', __name__)

# POST route for handling contact form submission
@contact_bp.route('/', methods=['POST'])
def submit_contact_form():
    try:
        # Access form data using request
        data = request.form
        name = data.get('name')
        email = data.get('email')
        message = data.get('message')

        # Perform necessary operations (e.g. send email, save to database)
        # For example, send email using smtplib
        sender_email = 'your-email@example.com'
        receiver_email = 'recipient@example.com'
        password = 'your-password'

        msg = MIMEMultipart()
        msg['From'] = sender_email
        msg['To'] = receiver_email
        msg['Subject'] = 'New Contact Form Submission'

        body = f"Name: {name}\nEmail: {email}\nMessage: {message}"
        msg.attach(MIMEText(body, 'plain'))

        with smtplib.SMTP('smtp.gmail.com', 587) as server:
            server.starttls()
            server.login(sender_email, password)
            server.send_message(msg)

        # Save form data to the database
        db.ContactForm.create(
            name=name,
            email=email,
            message=message
        )

        # Send appropriate response to the client
        return redirect(url_for('contact.success'))
    except Exception as e:
        # If an error occurs, redirect to the error page
        print('Error submitting contact form:', e)
        return redirect(url_for('contact.error'))

# POST route for handling contact form submission with different URL
@contact_bp.route('/submit', methods=['POST'])
def submit_contact_form_alt():
    try:
        # Access form data using request
        data = request.form
        name = data.get('name')
        email = data.get('email')
        message = data.get('message')

        # Perform necessary operations (e.g. send email, save to database)
        # For example, send email using smtplib
        sender_email = 'your-email@example.com'
        receiver_email = 'recipient@example.com'
        password = 'your-password'

        msg = MIMEMultipart()
        msg['From'] = sender_email
        msg['To'] = receiver_email
        msg['Subject'] = 'New Contact Form Submission'

        body = f"Name: {name}\nEmail: {email}\nMessage: {message}"
        msg.attach(MIMEText(body, 'plain'))

        with smtplib.SMTP('smtp.gmail.com', 587) as server:
            server.starttls()
            server.login(sender_email, password)
            server.send_message(msg)

        # Save form data to the database
        db.ContactForm.create(
            name=name,
            email=email,
            message=message
        )

        # Send appropriate response to the client
        return redirect(url_for('contact.success'))
    except Exception as e:
        # If an error occurs, redirect to the error page
        print('Error submitting contact form:', e)
        return redirect(url_for('contact.error'))
