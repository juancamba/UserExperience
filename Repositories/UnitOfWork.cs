using UserExperience.Database;

namespace UserExperience.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IWorkingExperienceRepository WorkingExperienceRepository { get; }
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context, IUserRepository userRepository, IWorkingExperienceRepository workingExperienceRepository)
        {
            _context = context;
            UserRepository = userRepository;
            WorkingExperienceRepository = workingExperienceRepository;
        }

        public async Task<int> Save()
        {

            // if error occurs, it will throw an exception and the transaction will be rolled back



            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
