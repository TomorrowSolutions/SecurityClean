using System.ComponentModel.DataAnnotations;

namespace SecurityClean3.Models.ViewModels
{
    public class RegistrationVM
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Эл. почта")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "ФИО")]
        public string FullName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
    }
}
