using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SecurityClean3.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [Display(Name = "Дата подписания")]
        public string FullName { get; set; }
        [Timestamp]
        [ValidateNever]
        public byte[] RowVersion { get; set; }
    }
}
