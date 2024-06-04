using System.ComponentModel.DataAnnotations;

namespace SecurityClean3.Models.ViewModels
{
    public class UserRolesVM
    {
        public ApplicationUser User { get; set; }
        [Display(Name = "Полномочия")]
        public IEnumerable<string> Roles { get; set; }
    }
}
