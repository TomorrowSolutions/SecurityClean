using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityClean3.Models
{
    public class ContractSecuredItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "Contract", ResourceType = typeof(Resources.Models.ContractDetails))]
        public int ContractId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "SecuredItem", ResourceType = typeof(Resources.Models.ContractDetails))]
        public int SecuredItemId { get; set; }

        [ForeignKey("ContractId")]
        [Display(Name = "Contract", ResourceType = typeof(Resources.Models.ContractDetails))]
        public Contract? Contract { get; set; }
        [ForeignKey("SecuredItemId")]
        [Display(Name = "SecuredItem", ResourceType = typeof(Resources.Models.ContractDetails))]
        public SecuredItem? SecuredItem { get; set; }
        [Timestamp]
        [ValidateNever]
        public byte[] RowVersion { get; set; }
    }
}
