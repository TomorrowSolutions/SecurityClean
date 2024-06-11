using System.ComponentModel.DataAnnotations;

namespace SecurityClean3.Models.ViewModels
{
    public class ChangeRoleVM
    {
        [Required]
        public string Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "ChooseRole", ResourceType = typeof(Resources.General.Crud))]
        public bool IsAdmin { get; set; }
    }
}
