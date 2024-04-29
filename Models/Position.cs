using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SecurityClean3.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [StringLength(50, ErrorMessage = "Поле {0} не должно превышать {1} символов.")]
        public string Name { get; set; } = "";
        [Range(0, 3000000.00)]
        [Display(Name = "Оклад")]
        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        public double Wage { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<Service>? Services { get; set; }
        [Timestamp]
        [ValidateNever]
        public byte[] RowVersion { get; set; }
    }
}
