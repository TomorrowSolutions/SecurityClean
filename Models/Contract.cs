﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SecurityClean3.Models
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [Display(Name = "Номер заказчика")]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Display(Name = "Заказчик")]
        public Customer? Customer { get; set; }

        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [Display(Name = "Дата подписания")]
        [DataType(DataType.Date)]
        public DateTime SignDate { get; set; }

        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [Display(Name = "Дата начала действия")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [Display(Name = "Дата окончания действия")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Поле {0} обязательно для заполнения.")]
        [Display(Name = "Заблокирован")]
        public bool IsLocked { get; set; }
        [Display(Name = "Путь к файлу договора")]
        public string? FileName { get; set; }

        [Timestamp]
        [ValidateNever]
        public byte[] RowVersion { get; set; }
        public ICollection<ContractSecuredItem>? ContractSecuredItems { get; set; }
        public ICollection<ContractService>? ContractServices { get; set; }
    }
}
