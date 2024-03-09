
using Microsoft.AspNetCore.Mvc;
using UserExperience.Models;

namespace UserExperience.Repositories
{
    public interface IUserRepository
    {
        Task<User> Insert(User user);
        Task<User?> GetById(int id);
        Task<IEnumerable<User>> GetUsers();
    }
}
