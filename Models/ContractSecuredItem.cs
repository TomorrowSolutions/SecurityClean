using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityClean3.Models
{
    public class ContractSecuredItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [Display(Name = "Номер договора")]
        public int ContractId { get; set; }
        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [Display(Name = "Номер объекта")]
        public int SecuredItemId { get; set; }

        [ForeignKey("ContractId")]
        [Display(Name = "Договор")]
        public Contract? Contract { get; set; }
        [ForeignKey("SecuredItemId")]
        [Display(Name = "Объект")]
        public SecuredItem? SecuredItem { get; set; }
        [Timestamp]
        [ValidateNever]
        public byte[] RowVersion { get; set; }
    }
}
