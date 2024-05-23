using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SecurityClean3.Models
{
    public class ContractService
    {
        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [Display(Name = "Номер договора")]
        public int ContractId { get; set; }
        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [Display(Name = "Номер услуги")]
        public int ServiceId { get; set; }

        [ForeignKey("ContractId")]
        [Display(Name = "Договор")]
        public Contract? Contract { get; set; }
        [ForeignKey("ServiceId")]
        [Display(Name = "Услуга")]
        public Service? Service { get; set; }
    }
}
