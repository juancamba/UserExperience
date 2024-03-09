using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UserExperience.Database;
using UserExperience.Models;

namespace UserExperience.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Insert(User user)
        {
            EntityEntry<User> insertedUser = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return insertedUser.Entity;
        }

        public async Task<User?> GetById(int id)
            => await _context.Users
                .Include(a => a.Workingexperiences)
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
