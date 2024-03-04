using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Psychosis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        // Sample data for demonstration
        private readonly List<User> users = new List<User>
        {
            new User { Id = 1, Name = "John Doe" },
            new User { Id = 2, Name = "Jane Smith" },
            new User { Id = 3, Name = "Bob Johnson" }
        };

        // Middleware for error handling
        private IActionResult HandleValidationErrors()
        {
            return BadRequest(ModelState);
        }

        // Middleware for authentication (dummy implementation)
        private IActionResult AuthenticateUser()
        {
            // Dummy check for authentication (replace with actual implementation)
            bool isAuthenticated = true; // Example: Check if user is authenticated
            if (!isAuthenticated)
            {
                return Unauthorized();
            }
            return null;
        }

        // Define user routes
        [HttpGet]
        public IActionResult GetUsers()
        {
            // Dummy authentication
            IActionResult authResult = AuthenticateUser();
            if (authResult != null)
            {
                return authResult;
            }
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            // Dummy authentication
            IActionResult authResult = AuthenticateUser();
            if (authResult != null)
            {
                return authResult;
            }

            // Dummy validation
            if (!ModelState.IsValid)
            {
                return HandleValidationErrors();
            }

            var user = users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { error = "User not found" });
            }
            return Ok(user);
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
