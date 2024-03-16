using Microsoft.EntityFrameworkCore;
using UserExperience.Database;
using UserExperience.Models;

namespace UserExperience.Repositories
{
    public class WorkingExperienceRepository : IWorkingExperienceRepository
    {
        private readonly AppDbContext _context;

        public WorkingExperienceRepository(AppDbContext cursoEfContext)
        {
            _context = cursoEfContext;
        }

        public async Task Insert(List<Workingexperience> workingExperiences)
        {
            await _context.Workingexperiences.AddRangeAsync(workingExperiences);
            //await _context.SaveChangesAsync();

        }


    }
}
