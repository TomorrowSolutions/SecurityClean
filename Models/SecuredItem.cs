using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SecurityClean3.Models
{
    public class SecuredItem
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [Display(Name = "Название")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [Display(Name = "Адрес")]
        [StringLength(150)]
        public string Address { get; set; } = string.Empty;
        [Timestamp]
        [ValidateNever]
        public byte[] RowVersion { get; set; }
        public ICollection<ContractSecuredItem>? ContractSecuredItems { get; set; }
    }
}
