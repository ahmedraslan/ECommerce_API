using System.ComponentModel.DataAnnotations;

namespace E_Commerce.API.DTOs
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null;

        [Required]     
        public string Password { get; set; } = null;

    }
}
