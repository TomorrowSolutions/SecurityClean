using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecurityClean3.Models;

namespace SecurityClean3.Data
{
    public class SecurityContext : IdentityDbContext<ApplicationUser>
    {
        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options)
        {
        }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<SecuredItem> SecuredItems { get; set; }

        public DbSet<ContractSecuredItem> ContractSecuredItems { get; set; }
        public DbSet<ContractService> ContractServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Position>().Property(p => p.RowVersion).IsConcurrencyToken();
            modelBuilder.Entity<Position>().HasData(
                    new Position
                    {
                        Id = 1,
                        Name = "Специалист по монтированию",
                        Wage = 26000
                    },
                    new Position
                    {
                        Id = 2,
                        Name = "Охранник",
                        Wage = 35000
                    },
                    new Position
                    {
                        Id = 3,
                        Name = "Телохранитель",
                        Wage = 75000
                    },
                    new Position
                    {
                        Id = 4,
                        Name = "Водитель",
                        Wage = 30000
                    },
                    new Position
                    {
                        Id = 5,
                        Name = "Системный администратор",
                        Wage = 32500
                    }
                );
            modelBuilder.Entity<Employee>().HasData(
                    new Employee
                    {
                        Id = 1,
                        FullName = "Иванов Иван Иванович",
                        HireDate = new DateTime(2018, 03, 01),
                        Education = "Среднее профессиональное образование, специальность Охранник",
                        PositionId = 3
                    },
                    new Employee
                    {
                        Id = 2,
                        FullName = "Петрова Елена Сергеевна",
                        HireDate = new DateTime(2019, 07, 15),
                        Education = "Высшее образование, специальность Экономист",
                        PositionId = 4
                    },
                    new Employee
                    {
                        Id = 3,
                        FullName = "Сидоров Александр Николаевич",
                        HireDate = new DateTime(2020, 11, 20),
                        Education = "Среднее общее образование",
                        PositionId = 1
                    },
                    new Employee
                    {
                        Id = 4,
                        FullName = "Кузнецова Наталья Владимировна",
                        HireDate = new DateTime(2021, 02, 10),
                        Education = "Высшее образование, специальность 'Компьютерные науки и технологии'",
                        PositionId = 5
                    },
                    new Employee
                    {
                        Id = 5,
                        FullName = "Михайлов Михаил Алексеевич",
                        HireDate = new DateTime(2021, 06, 05),
                        Education = "Среднее профессиональное образование, специальность Охранник",
                        PositionId = 2
                    }
                );
                //Метод позволяет заполнить таблицу данными
            modelBuilder.Entity<Service>().HasData(
                //Каждый объект будет преобразован в строку таблицы
               new Service { Id = 1, Name = "Установка видеонаблюдения", Price = 50000.00, PositionId = 1 },
                new Service { Id = 2, Name = "Обслуживание системы видеонаблюдения", Price = 70000.00, PositionId = 5 },
                new Service { Id = 3, Name = "Перевозка грузов", Price = 60000.00, PositionId = 4 },
                new Service { Id = 4, Name = "Охрана объектов", Price = 30000.00, PositionId = 2 },
                new Service { Id = 5, Name = "Персональная охрана", Price = 80000.00, PositionId = 3 }
                );
            string AdminGuid = Guid.NewGuid().ToString();
            string ManagerGuid = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = AdminGuid, Name = Utils.Roles.Admin, NormalizedName = Utils.Roles.Admin },
                new IdentityRole { Id = ManagerGuid, Name = Utils.Roles.Manager, NormalizedName = Utils.Roles.Manager }
                );
            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = AdminGuid,
                    UserName = "admin@mail.com",
                    NormalizedUserName = "admin@mail.com",
                    Email = "admin@mail.com",
                    NormalizedEmail = "admin@mail.com",
                    FullName = "admin",
                    PasswordHash = hasher.HashPassword(null, "masterkey"),
                    SecurityStamp = string.Empty
                },
                new ApplicationUser
                {
                    Id = ManagerGuid,
                    UserName = "manager@mail.com",
                    NormalizedUserName = "manager@mail.com",
                    Email = "manager@mail.com",
                    NormalizedEmail = "manager@mail.com",
                    FullName = "manager",
                    PasswordHash = hasher.HashPassword(null, "masterkey"),
                    SecurityStamp = string.Empty
                }
                );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = AdminGuid, UserId = AdminGuid },
                new IdentityUserRole<string> { RoleId = ManagerGuid, UserId = ManagerGuid }
                );
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    CompanyName = "ООО Рога и копыта",
                    LegalAddress = "123000, г. Москва, ул. Ромашковая, д. 1",
                    Inn = "7701010012",
                    AccountNumber = "40702810100000000001",
                    Bank = "ПАО Сбербанк",
                    Bik = "044525225",
                    CorrespondentAccount = "30101810200000000225",
                    ContactPerson = "Иванов Иван Иванович"
                },
                new Customer
                {
                    Id = 2,
                    CompanyName = "ПАО ЖЭК",
                    LegalAddress = "123000, г. Москва, ул. Клавишная, д. 2",
                    Inn = "7702020014",
                    AccountNumber = "40702810100000000002",
                    Bank = "ПАО Сбербанк",
                    Bik = "044525225",
                    CorrespondentAccount = "30101810200000000225",
                    ContactPerson = "Петров Петр Петрович"
                },
                new Customer
                {
                    Id = 3,
                    CompanyName = "ООО МикроАванс",
                    LegalAddress = "123000, г. Москва, ул. Ладожская, д. 3",
                    Inn = "7703030016",
                    AccountNumber = "40702810100000000003",
                    Bank = "ПАО Сбербанк",
                    Bik = "044525225",
                    CorrespondentAccount = "30101810200000000225",
                    ContactPerson = "Сидоров Сидр Сидрович"
                },

                new Customer
                {
                    Id = 4,
                    CompanyName = "ОАО Гофры",
                    LegalAddress = "123000, г. Москва, ул. Букетиров, д. 4",
                    Inn = "7704040018",
                    AccountNumber = "40702810100000000004",
                    Bank = "ПАО Сбербанк",
                    Bik = "044525225",
                    CorrespondentAccount = "30101810200000000225",
                    ContactPerson = "Кузнецов Кузьма Кузьмич"
                },
                new Customer
                {
                    Id = 5,
                    CompanyName = "ООО БК Всех и каждого",
                    LegalAddress = "123000, г. Москва, ул. Галошная, д. 5",
                    Inn = "7705050011",
                    AccountNumber = "40702810100000000005",
                    Bank = "ПАО Сбербанк",
                    Bik = "044525225",
                    CorrespondentAccount = "30101810200000000225",
                    ContactPerson = "Лебедев Лев Лебедевич"
                }
                );
            modelBuilder.Entity<Contract>().HasData(
                new Contract
                {
                    Id = 1,
                    CustomerId = 1,
                    SignDate = new DateTime(2022, 1, 1),
                    StartDate = new DateTime(2022, 1, 1),
                    EndDate = new DateTime(2022, 12, 31),
                    IsLocked = false
                }
                );
            modelBuilder.Entity<SecuredItem>().HasData(
                new SecuredItem { Id = 1, Name = "Банк", Address = "ул. Тверская, 1, Москва, Россия" },
                new SecuredItem { Id = 2, Name = "Ювелирный салон", Address = "пр. Независимости, 15, Минск, Беларусь" },
                new SecuredItem { Id = 3, Name = "Автоцентр", Address = "ул. Большая Спасская, 24, Санкт-Петербург, Россия" },
                new SecuredItem { Id = 4, Name = "Музей", Address = "пр. Победителей, 50, Минск, Беларусь" },
                new SecuredItem { Id = 5, Name = "Театр", Address = "ул. Театральная, 10, Москва, Россия" }
                );
            modelBuilder.Entity<ContractSecuredItem>(e =>
            {

                e.HasOne(x => x.Contract)
                .WithMany(y => y.ContractSecuredItems)
                .HasForeignKey(x => x.ContractId)
                .OnDelete(DeleteBehavior.Cascade);


                e.HasOne(x => x.SecuredItem)
                .WithMany(y => y.ContractSecuredItems)
                .HasForeignKey(x => x.SecuredItemId)
                .OnDelete(DeleteBehavior.Cascade);

                e.HasData(
                    new ContractSecuredItem { Id = 1, ContractId = 1, SecuredItemId = 1 },
                    new ContractSecuredItem { Id = 2, ContractId = 1, SecuredItemId = 2 },
                    new ContractSecuredItem { Id = 3, ContractId = 1, SecuredItemId = 3 }
                    );
            });
            modelBuilder.Entity<ContractService>(e =>
            {

                e.HasOne(x => x.Contract)
                .WithMany(y => y.ContractServices)
                .HasForeignKey(x => x.ContractId)
                .OnDelete(DeleteBehavior.Cascade);


                e.HasOne(x => x.Service)
                .WithMany(y => y.ContractServices)
                .HasForeignKey(x => x.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

                e.HasData(
                    new ContractService { Id = 1, ContractId = 1, ServiceId = 1 },
                    new ContractService { Id = 2, ContractId = 1, ServiceId = 2 },
                    new ContractService { Id = 3, ContractId = 1, ServiceId = 4 }
                    );
            });
            modelBuilder.Entity<Contract>().Property(p => p.RowVersion).IsConcurrencyToken();
            modelBuilder.Entity<Employee>().Property(p => p.RowVersion).IsConcurrencyToken();
            modelBuilder.Entity<Service>().Property(p => p.RowVersion).IsConcurrencyToken();
            modelBuilder.Entity<Customer>().Property(p => p.RowVersion).IsConcurrencyToken();
            modelBuilder.Entity<SecuredItem>().Property(p => p.RowVersion).IsConcurrencyToken();
            modelBuilder.Entity<ContractSecuredItem>().Property(p => p.RowVersion).IsConcurrencyToken();
            modelBuilder.Entity<ContractService>().Property(p => p.RowVersion).IsConcurrencyToken();
        }
    }
}
