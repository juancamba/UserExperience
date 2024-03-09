using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserExperience.Models;

namespace UserExperience.Database.SeedData
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
               new User { Email = "example1@mail.com", Id = 1, UserName = "user1", Web = "www.google.es", Direccion = string.Empty },
               new User { Email = "user2@mail.com", Id = 2, UserName = "user2", Web = "www.yahoo.es", Direccion = string.Empty }
           );
        }
    }
}
