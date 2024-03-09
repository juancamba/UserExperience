using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using UserExperience.Database;
using UserExperience.Models;
using UserExperience.Repositories;

namespace UserExperience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {


        private readonly IUserRepository _userRepository;
        private readonly IWorkingExperienceRepository _workingExperienceRepository;
        public UsersController(IUserRepository userRepository, IWorkingExperienceRepository workingExperienceRepository)
        {

            _userRepository = userRepository;
            _workingExperienceRepository = workingExperienceRepository;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userRepository.GetById(id);



            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(int idUser)
        {
            User user1 = await _userRepository.GetById(idUser);
            if (user1 == null)
            {
                return NotFound();
            }
            List<Workingexperience> workingExperiences1 = new List<Workingexperience>()
            {
                        new Workingexperience()
                {
                    UserId = user1.Id,
                    Name = "experience 1",
                    Details = "details1",
                    Environment = "environment"
                },
                new Workingexperience()
                {
                    UserId = user1.Id,
                    Name = "experience 2",
                    Details = "details2",
                    Environment = "environment"
                }
            };

            await _workingExperienceRepository.Insert(workingExperiences1);

            return CreatedAtAction("GetUser", new { id = user1.Id }, user1);
        }


    }
}
