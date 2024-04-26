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
        public string Name { get; set; } = "";
        [Range(0, 3000000.00)]
        [Display(Name = "Стоимость")]
        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        public double Price { get; set; }
    }
}
