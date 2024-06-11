using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SecurityClean3.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "FullName", ResourceType = typeof(Resources.Models.Employee))]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "HireDate", ResourceType = typeof(Resources.Models.Employee))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "Education", ResourceType = typeof(Resources.Models.Employee))]
        [StringLength(100)]
        public string Education { get; set; } = string.Empty;
        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "Position", ResourceType = typeof(Resources.Models.Employee))]
        public int PositionId { get; set; }
        [ForeignKey("PositionId")]
        [Display(Name = "Position", ResourceType = typeof(Resources.Models.Employee))]
        public Position? Position { get; set; }

        [Timestamp]
        [ValidateNever]
        public byte[] RowVersion { get; set; }
    }
}
