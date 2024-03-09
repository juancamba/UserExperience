using UserExperience.Models;
using UserExperience.Repositories;

namespace UserExperience.Services
{
    public class InsertUser
    {
        private readonly IUnitOfWork _unitOfWork;

        public InsertUser(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Execute(int id)
        {
            User user = new User()
            {
                Email = $"{Guid.NewGuid()}@mail.com",
                UserName = $"id{id}",
                Direccion = "",
                Web = ""
            };

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
                Name = $"experience1 user {id}",
                Details = "details1",
                Environment = "environment"
            },
            new Workingexperience()
            {
                User = user,
                Name = $"experience user {id}",
                Details = "details2",
                Environment = "environment"
            }
        };

            _ = await _unitOfWork.UserRepository.Insert(user);
            await _unitOfWork.WorkingExperienceRepository.Insert(workingExperiences);
            _ = await _unitOfWork.Save();

            return true;
        }
    }
}
