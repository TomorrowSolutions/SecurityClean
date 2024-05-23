using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SecurityClean3.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LegalAddress { get; set; } = string.Empty;

        [Required]
        [StringLength(12, MinimumLength = 10)]
        [RegularExpression(@"^\d+$")]
        public string Inn { get; set; } = string.Empty;

        [Required]
        [StringLength(20, MinimumLength = 20)]
        [RegularExpression(@"^\d+$")]
        public string AccountNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Bank { get; set; } = string.Empty;

        [Required]
        [StringLength(9, MinimumLength = 9)]
        [RegularExpression(@"^\d+$")]
        public string Bik { get; set; } = string.Empty;

        [StringLength(20, MinimumLength = 20)]
        [RegularExpression(@"^\d+$")]
        public string? CorrespondentAccount { get; set; }

        [Required]
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

        public ICollection<Contract>? contracts { get; set; }
    }
}
