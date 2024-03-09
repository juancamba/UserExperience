namespace UserExperience.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IWorkingExperienceRepository WorkingExperienceRepository { get; }
        Task<int> Save();
    }
}
