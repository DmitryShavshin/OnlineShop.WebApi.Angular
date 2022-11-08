using System.ComponentModel.DataAnnotations;


namespace OnlineShop.WebApi.Angular.Models.DTOs
{
    public class RegistrationRequestDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordConfirm { get; set; }
    }
}