using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SecurityClean3.Models
{
    public class SecuredItem
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "Name", ResourceType = typeof(Resources.Models.SecuredItem))]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "Address", ResourceType = typeof(Resources.Models.SecuredItem))]
        [StringLength(150)]
        public string Address { get; set; } = string.Empty;
        [Timestamp]
        [ValidateNever]
        public byte[] RowVersion { get; set; }
        public ICollection<ContractSecuredItem>? ContractSecuredItems { get; set; }
    }
}
