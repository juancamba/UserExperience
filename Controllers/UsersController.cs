using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using UserExperience.Database;
using UserExperience.Models;

namespace UserExperience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users
                .Include(u => u.Wokringexperiences)
                .FirstOrDefaultAsync(a => a.Id == id);




            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(int idUser)
        {
            User user1 = await _context.Users.FindAsync(idUser);
            if (user1 == null)
            {
                return NotFound();
            }
            List<Wokringexperience> workingExperiences1 = new List<Wokringexperience>()
            {
                        new Wokringexperience()
                {
                    UserId = user1.Id,
                    Name = "experience 1",
                    Details = "details1",
                    Environment = "environment"
                },
                new Wokringexperience()
                {
                    UserId = user1.Id,
                    Name = "experience 2",
                    Details = "details2",
                    Environment = "environment"
                }
            };

            _context.Wokringexperiences.AddRange(workingExperiences1);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = user1.Id }, user1);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
