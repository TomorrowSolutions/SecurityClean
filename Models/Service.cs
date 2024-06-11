using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityClean3.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "Name", ResourceType = typeof(Resources.Models.Service))]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Range(0, 3000000.00, ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "NumberBetween")]
        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "Price", ResourceType = typeof(Resources.Models.Service))]
        public double Price { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "Position", ResourceType = typeof(Resources.Models.Service))]
        public int PositionId { get; set; }
        [ForeignKey("PositionId")]
        [Display(Name = "Position", ResourceType = typeof(Resources.Models.Service))]
        public Position? Position { get; set; }

        [Timestamp]
        [ValidateNever]
        public byte[] RowVersion { get; set; }

        public ICollection<ContractService>? ContractServices { get; set; }
    }
}
