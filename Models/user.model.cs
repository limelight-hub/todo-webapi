using System.ComponentModel.DataAnnotations;

namespace MyApi.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}
