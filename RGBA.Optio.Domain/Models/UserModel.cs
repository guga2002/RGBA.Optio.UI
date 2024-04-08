using System.ComponentModel.DataAnnotations;

namespace RGBA.Optio.Domain.Models
{
    public class UserModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        public string PersonalNumber { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
