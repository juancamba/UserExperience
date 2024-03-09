using UserExperience.Database;
using UserExperience.Models;

namespace UserExperience
{
    public class PrepareDb
    {
        public static void Population(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        public static void SeedData(AppDbContext context)
        {
            //context.Database.EnsureCreated();
            // el seed data lo hacemos desde SeedData
        }
    }
}
