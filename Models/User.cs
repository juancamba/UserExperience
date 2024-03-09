using System.ComponentModel.DataAnnotations;

namespace UserExperience.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(255)]
        public string Web { get; set; }
        [MaxLength(255)]
        public string Direccion { get; set; }

        public ICollection<Wokringexperience> Wokringexperiences { get; set; } // <- this line
    }
}
