using System.ComponentModel.DataAnnotations;

namespace SecurityClean3.Models.ViewModels
{
    public class UserRolesVM
    {
        [Display(Name = "ApplicationUser", ResourceType = typeof(Resources.General.Crud))]
        public ApplicationUser User { get; set; }
        [Display(Name = "Roles", ResourceType = typeof(Resources.General.Crud))]
        public IEnumerable<string> Roles { get; set; }
    }
}
