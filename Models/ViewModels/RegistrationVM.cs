using System.ComponentModel.DataAnnotations;

namespace SecurityClean3.Models.ViewModels
{
    public class RegistrationVM
    {
        [Required( ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [EmailAddress]
        [Display(Name = "Email",ResourceType =typeof(Resources.Models.User))]
        public string Email { get; set; }

        [Required( ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "FullName", ResourceType = typeof(Resources.Models.User))]
        public string FullName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [StringLength(100, MinimumLength = 8,ErrorMessageResourceType =typeof(Resources.General.Errors),ErrorMessageResourceName = "LengthBetween")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Models.User))]
        public string Password { get; set; }

        [Required( ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "ChooseRole", ResourceType = typeof(Resources.General.Crud))]
        public bool IsAdmin { get; set; }
    }
}
