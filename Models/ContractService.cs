using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SecurityClean3.Models
{
    public class ContractService
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "Contract", ResourceType = typeof(Resources.Models.ContractDetails))]
        public int ContractId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "Service", ResourceType = typeof(Resources.Models.ContractDetails))]
        public int ServiceId { get; set; }
        [ForeignKey("ContractId")]
        [Display(Name = "Contract", ResourceType = typeof(Resources.Models.ContractDetails))]
        public Contract? Contract { get; set; }
        [ForeignKey("ServiceId")]
        [Display(Name = "Service", ResourceType = typeof(Resources.Models.ContractDetails))]
        public Service? Service { get; set; }
        [Timestamp]
        [ValidateNever]
        public byte[] RowVersion { get; set; }
    }
}
