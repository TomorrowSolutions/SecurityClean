using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SecurityClean3.Models
{
    public class Contract
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime SignDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public ICollection<ContractSecuredItem>? ContractSecuredItems { get; set; }
        public ICollection<ContractService>? ContractServices { get; set; }
    }
}
