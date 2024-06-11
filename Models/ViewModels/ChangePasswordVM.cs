using System.ComponentModel.DataAnnotations;

namespace SecurityClean3.Models.ViewModels
{
    public class ChangePasswordVM
    {
        [Required]
        public string Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [StringLength(100, MinimumLength = 8, ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "LengthBetween")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Models.User))]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources.Models.User))]
        [Compare("Password", ErrorMessageResourceType =typeof(Resources.General.Errors),ErrorMessageResourceName ="PasswordMatch")]
        public string ConfirmPassword { get; set; }
    }
}
