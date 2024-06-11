using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SecurityClean3.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "CompanyName", ResourceType = typeof(Resources.Models.Customer))]
        [StringLength(100)]
        public string CompanyName { get; set; } = string.Empty;

        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "LegalAddress", ResourceType = typeof(Resources.Models.Customer))]
        [StringLength(100)]
        public string LegalAddress { get; set; } = string.Empty;

        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "Inn", ResourceType = typeof(Resources.Models.Customer))]
        [StringLength(12, MinimumLength = 10, ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "LengthBetween")]
        public string Inn { get; set; } = string.Empty;

        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "AccountNumber", ResourceType = typeof(Resources.Models.Customer))]
        [StringLength(20, MinimumLength = 20, ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "LengthBetween")]
        public string AccountNumber { get; set; } = string.Empty;

        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "Bank", ResourceType = typeof(Resources.Models.Customer))]
        [StringLength(100)]
        public string Bank { get; set; } = string.Empty;

        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "Bik", ResourceType = typeof(Resources.Models.Customer))]
        [StringLength(9, MinimumLength = 9, ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "LengthBetween")]
        public string Bik { get; set; } = string.Empty;

        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "CorrespondentAccount", ResourceType = typeof(Resources.Models.Customer))]
        [StringLength(20, MinimumLength = 20, ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "LengthBetween")]
        public string? CorrespondentAccount { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "ContactPerson", ResourceType = typeof(Resources.Models.Customer))]
        [StringLength(100)]
        public string ContactPerson { get; set; } = string.Empty;

        public override string? ToString()
        {
            return $"{CompanyName } " +
               $" ИНН: {Inn}\n" +
               $"Юр. адрес: {LegalAddress}\n"+
               $"р/с: {AccountNumber}\n" +
               $"в банке:{Bank}\n" +
               $"корр. счет сч:{(CorrespondentAccount == null ?  "(корр. счета нет)":CorrespondentAccount)}\n"+
               $"БИК: {Bik}\n";
        }

        [Timestamp]
        [ValidateNever]
        public byte[] RowVersion { get; set; }

        public ICollection<Contract>? contracts { get; set; }

        public string getShortFio()
        {
            var strings = this.ContactPerson.Split(' ');
            Queue<string> fioQueue = new Queue<string>(strings);
            StringBuilder sb = new StringBuilder();
            var Family = fioQueue.Dequeue();
            sb.Append(Family + " ");
            while (fioQueue.Count > 0)
            {
                var tmp = fioQueue.Dequeue().First().ToString().ToUpper();
                sb.Append(tmp + ".");
            }
            return sb.ToString();
        }
    }
}
