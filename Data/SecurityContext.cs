using Microsoft.EntityFrameworkCore;
using SecurityClean3.Models;

namespace SecurityClean3.Data
{
    public class SecurityContext : DbContext
    {
        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options)
        {
        }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
            modelBuilder.Entity<Service>().HasData(
               new Service { Id = 1, Name = "Установка видеонаблюдения", Price = 50000.00, PositionId=1 },
                new Service { Id = 2, Name = "Обслуживание системы видеонаблюдения", Price = 70000.00, PositionId=5 },
                new Service { Id = 3, Name = "Перевозка грузов", Price = 60000.00, PositionId=4 },
                new Service { Id = 4, Name = "Охрана объектов", Price = 30000.00 ,PositionId=2},
                new Service { Id = 5, Name = "Персональная охрана", Price = 80000.00,PositionId=3 }
                );
        }
    }
}
