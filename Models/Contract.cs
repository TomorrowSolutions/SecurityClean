using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SecurityClean3.Models
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "Customer", ResourceType = typeof(Resources.Models.Contract))]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Display(Name = "Customer", ResourceType = typeof(Resources.Models.Contract))]
        public Customer? Customer { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "SignDate", ResourceType = typeof(Resources.Models.Contract))]
        [DataType(DataType.Date)]
        public DateTime SignDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "StartDate", ResourceType = typeof(Resources.Models.Contract))]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "EndDate", ResourceType = typeof(Resources.Models.Contract))]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "IsLocked", ResourceType = typeof(Resources.Models.Contract))]
        public bool IsLocked { get; set; }
        public string? FileName { get; set; }

        [Timestamp]
        [ValidateNever]
        public byte[] RowVersion { get; set; }
        public ICollection<ContractSecuredItem>? ContractSecuredItems { get; set; }
        public ICollection<ContractService>? ContractServices { get; set; }
    }
}
