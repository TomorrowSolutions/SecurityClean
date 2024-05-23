using System.ComponentModel.DataAnnotations;

namespace SecurityClean3.Models
{
    public class SecuredItem
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(150)]
        public string Address { get; set; } = string.Empty;
        public ICollection<ContractSecuredItem>? ContractSecuredItems { get; set; }
    }
}
