using System.ComponentModel.DataAnnotations;

namespace MoshMVC.Models
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public required string EmailAddress { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
