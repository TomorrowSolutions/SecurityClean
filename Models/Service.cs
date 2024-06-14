using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityClean3.Models
{
    public class Service
    {
        //Аннотация обозначает первичный ключ
        [Key]
        //Поле первичного ключа
        public int Id { get; set; }
        //Аннотация обозначает что поле обязательно к заполнению
        //В случае если поле оказывается не заполнено, сообщение об ошибке берется из файла ресурсов
        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        //Аннотация обозначает имя поля, которое будет выводится пользователю. Его значение также берется из файла ресурсов
        [Display(Name = "Name", ResourceType = typeof(Resources.Models.Service))]
        //Аннотация позволяет задать максимальную длину строки
        [StringLength(50)]
        //Так как тип переменной в C# ссылочный, то при выходе из конструктора должен быть инициализирован
        //потому что переменная не предполагает наличие в ней значений null
        public string Name { get; set; } = string.Empty;
        //Аннотация позволяет задать охват числовой переменной. 
        //В случае если значение выходит за границы, сообщение об ошибке берется из файла ресурсов
        [Range(0, 3000000.00, ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "NumberBetween")]
        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "Price", ResourceType = typeof(Resources.Models.Service))]
        public double Price { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.General.Errors), ErrorMessageResourceName = "Fill")]
        [Display(Name = "Position", ResourceType = typeof(Resources.Models.Service))]
        public int PositionId { get; set; }
        //Аннотация позволяет задать внешний ключ таким образом что реальное значение хранится в переменной типа int
        //А переменная типа модели на которую идет ссылка используется для удобства извлечения связанных данных
        [ForeignKey("PositionId")]
        [Display(Name = "Position", ResourceType = typeof(Resources.Models.Service))]
        //Поле объявлено как nullable, так как необязательно к заполнению и в базе данных его нет
        public Position? Position { get; set; }
        //Версия записи в базе
        //При каждом обновлении меняется и таким образом подавляет состояние конкуренции
        [Timestamp]
        //Аннотация обозначает, что хотя данное поле и не является nullable
        //При валидации его необходимо игнорировать(значение всегда заполняет SQL Server)
        [ValidateNever]
        public byte[] RowVersion { get; set; }
        //Навигационное поле позволяет получить приложения к договорам в которых фигурирует данная услуга
        public ICollection<ContractService>? ContractServices { get; set; }
    }
}
