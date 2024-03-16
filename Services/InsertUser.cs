using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using UserExperience.Dto;
using UserExperience.Exceptions;
using UserExperience.Models;
using UserExperience.Models.Validations;
using UserExperience.Repositories;

namespace UserExperience.Services
{
    public class InsertUser
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        IValidator<User> _userValidator;
        public InsertUser(IUnitOfWork unitOfWork, IMapper mapper, IValidator<User> userValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userValidator = userValidator;
        }

        public async Task<bool> Execute(UserCreate userCreate)
        {

            User user = _mapper.Map<User>(userCreate);
            /*
            User user = new User()
            {
                Email = $"{Guid.NewGuid()}@mail.com",
                UserName = $"id{id}",
                Direccion = "",
                Web = ""
            };
            */
            /*
             * update
            User user = await _unitOfWork.UserRepository.GetById(id);
            if (user == null)
            {
                throw new Exception("user not found");
            }
            */
            List<Workingexperience> workingExperiences = new List<Workingexperience>()
            {
                new Workingexperience()
                {
                    User = user,
                    Name = $"experience1 user {user.UserName}",
                    Details = "details1",
                    Environment = "environment"
                },
                new Workingexperience()
                {
                    User = user,
                    Name = $"experience user {user.UserName}",
                    Details = "details2",
                    Environment = "environment"
                }
            };



            var validationResult = await _userValidator.ValidateAsync(user);
            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid USER Request", validationResult);



            _ = await _unitOfWork.UserRepository.Insert(user);
            await _unitOfWork.WorkingExperienceRepository.Insert(workingExperiences);
            _ = await _unitOfWork.Save();

            return true;
        }
    }
}
