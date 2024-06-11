using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SecurityClean3.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required(ErrorMessageResourceType =typeof(Resources.General.Errors), ErrorMessageResourceName ="Fill")]
        [Display(Name = "FullName",ResourceType =typeof(Resources.Models.User))]
        public string FullName { get; set; }
        [Timestamp]
        [ValidateNever]
        public byte[] RowVersion { get; set; }
    }
}
