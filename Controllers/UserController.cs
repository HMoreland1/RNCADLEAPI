using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RNCADLEAPI.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNCADLEAPI.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context; // Replace with your actual DbContext type

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET api/user/all
        [HttpGet("all")]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }

        // POST api/user/add
        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok(user);
            }
            catch (DbUpdateException ex)
            {
                // Handle unique constraint violation or other DB-related errors
                return StatusCode(500, $"Error adding user: {ex.Message}");
            }
        }

        // PUT api/user/update/{id}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        {
            var existingUser = await _context.Users.FindAsync(id);

            if (existingUser == null)
            {
                return NotFound("User not found");
            }

            // Update existing user properties with new values
            existingUser.Username = updatedUser.Username;
            existingUser.Email = updatedUser.Email;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(existingUser);
            }
            catch (DbUpdateException ex)
            {
                // Handle unique constraint violation or other DB-related errors
                return StatusCode(500, $"Error updating user: {ex.Message}");
            }
        }

        // DELETE api/user/remove/{id}
        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("User deleted successfully");
        }
    }
}