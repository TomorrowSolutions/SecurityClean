using System.ComponentModel.DataAnnotations;

namespace SecurityClean3.Models.ViewModels
{
    public class ChangeRoleVM
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
    }
}
