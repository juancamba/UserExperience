using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using UserExperience.Database;
using UserExperience.Dto;
using UserExperience.Models;
using UserExperience.Repositories;
using UserExperience.Services;

namespace UserExperience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {


        private readonly IUserRepository _userRepository;
        private readonly IWorkingExperienceRepository _workingExperienceRepository;
        private readonly InsertUser _insertUser;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork, InsertUser insertUser)
        {


            _unitOfWork = unitOfWork;
            _insertUser = insertUser;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _unitOfWork.UserRepository.GetUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserCreate userCreate)
        {

            await _insertUser.Execute(userCreate);

            return Ok("User created!");
        }


    }
}
