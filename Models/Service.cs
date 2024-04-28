using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityClean3.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [StringLength(50, ErrorMessage = "Поле {0} не должно превышать {1} символов.")]
        public string Name { get; set; } = "";
        [Range(0, 3000000.00)]
        [Display(Name = "Стоимость")]
        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [Display(Name = "Должность")]
        public int PositionId { get; set; }
        [ForeignKey("PositionId")]
        [Display(Name = "Должность")]
        public Position? Position { get; set; }
    }
}
