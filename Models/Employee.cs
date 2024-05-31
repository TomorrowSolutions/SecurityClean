using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SecurityClean3.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [Display(Name = "ФИО")]
        [StringLength(100, ErrorMessage = "Поле {0} не должно превышать {1} символов.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [Display(Name = "Дата поступления на работу")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [Display(Name = "Образование")]
        [StringLength(100, ErrorMessage = "Поле {0} не должно превышать {1} символов.")]
        public string Education { get; set; } = string.Empty;
        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [Display(Name = "Должность")]
        public int PositionId { get; set; }
        [ForeignKey("PositionId")]
        [Display(Name = "Должность")]
        public Position? Position { get; set; }

        [Timestamp]
        [ValidateNever]
        public byte[] RowVersion { get; set; }
    }
}
