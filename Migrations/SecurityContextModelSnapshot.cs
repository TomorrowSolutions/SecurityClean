﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecurityClean3.Data;

#nullable disable

namespace SecurityClean3.Migrations
{
    [DbContext(typeof(SecurityContext))]
    partial class SecurityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SecurityClean3.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Education = "Среднее профессиональное образование, специальность Охранник",
                            FullName = "Иванов Иван Иванович",
                            HireDate = new DateTime(2018, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PositionId = 3
                        },
                        new
                        {
                            Id = 2,
                            Education = "Высшее образование, специальность Экономист",
                            FullName = "Петрова Елена Сергеевна",
                            HireDate = new DateTime(2019, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PositionId = 4
                        },
                        new
                        {
                            Id = 3,
                            Education = "Среднее общее образование",
                            FullName = "Сидоров Александр Николаевич",
                            HireDate = new DateTime(2020, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PositionId = 1
                        },
                        new
                        {
                            Id = 4,
                            Education = "Высшее образование, специальность 'Компьютерные науки и технологии'",
                            FullName = "Кузнецова Наталья Владимировна",
                            HireDate = new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PositionId = 5
                        },
                        new
                        {
                            Id = 5,
                            Education = "Среднее профессиональное образование, специальность Охранник",
                            FullName = "Михайлов Михаил Алексеевич",
                            HireDate = new DateTime(2021, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PositionId = 2
                        });
                });

            modelBuilder.Entity("SecurityClean3.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Wage")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Специалист по монтированию",
                            Wage = 26000.0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Охранник",
                            Wage = 35000.0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Телохранитель",
                            Wage = 75000.0
                        },
                        new
                        {
                            Id = 4,
                            Name = "Водитель",
                            Wage = 30000.0
                        },
                        new
                        {
                            Id = 5,
                            Name = "Системный администратор",
                            Wage = 32500.0
                        });
                });

            modelBuilder.Entity("SecurityClean3.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Установка видеонаблюдения",
                            PositionId = 1,
                            Price = 50000.0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Обслуживание системы видеонаблюдения",
                            PositionId = 5,
                            Price = 70000.0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Перевозка грузов",
                            PositionId = 4,
                            Price = 60000.0
                        },
                        new
                        {
                            Id = 4,
                            Name = "Охрана объектов",
                            PositionId = 2,
                            Price = 30000.0
                        },
                        new
                        {
                            Id = 5,
                            Name = "Персональная охрана",
                            PositionId = 3,
                            Price = 80000.0
                        });
                });

            modelBuilder.Entity("SecurityClean3.Models.Employee", b =>
                {
                    b.HasOne("SecurityClean3.Models.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("SecurityClean3.Models.Service", b =>
                {
                    b.HasOne("SecurityClean3.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("SecurityClean3.Models.Position", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
