using Microsoft.EntityFrameworkCore;
using UserExperience.Database.SeedData;
using UserExperience.Models;

namespace UserExperience.Database
{
    public class AppDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Workingexperience> Workingexperiences { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //this.ChangeTracker.LazyLoadingEnabled = false;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserSeed());
        }
    }
}
