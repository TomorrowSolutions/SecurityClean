using System.ComponentModel.DataAnnotations;

namespace SecurityClean3.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        public string Name { get; set; } = "";
        [Range(0, 3000000.00)]
        [Display(Name = "Заработная плата")]
        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        public double Wage { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
