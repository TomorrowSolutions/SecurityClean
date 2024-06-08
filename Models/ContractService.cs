using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SecurityClean3.Models
{
    public class ContractService
    {
        [Key]
        public int Id { get; set; }
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
        [Timestamp]
        [ValidateNever]
        public byte[] RowVersion { get; set; }
    }
}
