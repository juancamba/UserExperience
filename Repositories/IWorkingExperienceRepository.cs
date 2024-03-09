using UserExperience.Models;

namespace UserExperience.Repositories
{
    public interface IWorkingExperienceRepository
    {
        Task Insert(List<Workingexperience> workingExperiences);
    }
}
