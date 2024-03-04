// File: Robjam1990/Psychosis/Routes/UsersController.cs

using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;
using Robjam1990.Psychosis.Models; // Assuming you have a User model

namespace Robjam1990.Psychosis.Routes
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly YourDbContext _context; // Replace YourDbContext with your actual DbContext class name

        public UsersController(YourDbContext context)
        {
            _context = context;
        }

        // POST api/users/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            try
            {
                // Input validation
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Check if the user already exists
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    return BadRequest(new { error = "User with this email already exists." });
                }

                // Hash the password
                var hashedPassword = HashPassword(model.Password);

                // Create a new user object
                var newUser = new User
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = hashedPassword
                };

                // Save the user to the database
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                // Optionally send a verification email here

                // Respond with success message
                return CreatedAtAction(nameof(Register), new { message = "User registered successfully", user = newUser });
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Error registering user: {e.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An unexpected error occurred. Please try again later." });
            }
        }

        // Method to hash the password
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }

    // Model for input validation
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be at least 3 characters long")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }
    }
}
