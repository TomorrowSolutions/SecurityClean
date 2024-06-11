using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SecurityClean3.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "Name", ResourceType = typeof(Resources.Models.Position))]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Range(0, 3000000.00,ErrorMessageResourceType = typeof(Resources.General.Errors),ErrorMessageResourceName = "NumberBetween")]
        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "Wage", ResourceType = typeof(Resources.Models.Position))]
        public double Wage { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<Service>? Services { get; set; }
        [Timestamp]
        [ValidateNever]
        public byte[] RowVersion { get; set; }
    }
}
