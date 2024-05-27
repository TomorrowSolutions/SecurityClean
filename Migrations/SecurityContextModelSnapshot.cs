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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a26a9e76-a06d-40a6-b84a-4fec3a741ca2",
                            Name = "admin",
                            NormalizedName = "admin"
                        },
                        new
                        {
                            Id = "dc4ccf47-776f-4cc0-99cb-01572e53efd7",
                            Name = "manager",
                            NormalizedName = "manager"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "a26a9e76-a06d-40a6-b84a-4fec3a741ca2",
                            RoleId = "a26a9e76-a06d-40a6-b84a-4fec3a741ca2"
                        },
                        new
                        {
                            UserId = "dc4ccf47-776f-4cc0-99cb-01572e53efd7",
                            RoleId = "dc4ccf47-776f-4cc0-99cb-01572e53efd7"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SecurityClean3.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a26a9e76-a06d-40a6-b84a-4fec3a741ca2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "88f4e83b-ee62-43fd-92eb-2c379e16bec3",
                            Email = "admin@mail.com",
                            EmailConfirmed = false,
                            FullName = "admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@mail.com",
                            NormalizedUserName = "admin@mail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEInyeBPwUk3TB9EoPknAqnrQonyYs2wwi+UcPzCMRPj1NOj4d0kl6kBZ5czS2ayAKQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin@mail.com"
                        },
                        new
                        {
                            Id = "dc4ccf47-776f-4cc0-99cb-01572e53efd7",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0e72f3a2-9582-4070-8bf1-f5916d8cb3f0",
                            Email = "manager@mail.com",
                            EmailConfirmed = false,
                            FullName = "manager",
                            LockoutEnabled = false,
                            NormalizedEmail = "manager@mail.com",
                            NormalizedUserName = "manager@mail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEO8G2wqlCNpWITdZMYTjta2VV1TmhQRDmXW1zmTOqs5alrlvD5q+kTt7WKmFgwvv2g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "manager@mail.com"
                        });
                });

            modelBuilder.Entity("SecurityClean3.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("bit");

                    b.Property<DateTime>("SignDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Contracts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            EndDate = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsLocked = false,
                            SignDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SecurityClean3.Models.ContractSecuredItem", b =>
                {
                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<int>("SecuredItemId")
                        .HasColumnType("int");

                    b.HasKey("ContractId", "SecuredItemId");

                    b.HasIndex("SecuredItemId");

                    b.ToTable("ContractSecuredItems");

                    b.HasData(
                        new
                        {
                            ContractId = 1,
                            SecuredItemId = 1
                        },
                        new
                        {
                            ContractId = 1,
                            SecuredItemId = 2
                        },
                        new
                        {
                            ContractId = 1,
                            SecuredItemId = 3
                        });
                });

            modelBuilder.Entity("SecurityClean3.Models.ContractService", b =>
                {
                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("ContractId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ContractServices");

                    b.HasData(
                        new
                        {
                            ContractId = 1,
                            ServiceId = 1
                        },
                        new
                        {
                            ContractId = 1,
                            ServiceId = 2
                        },
                        new
                        {
                            ContractId = 1,
                            ServiceId = 4
                        });
                });

            modelBuilder.Entity("SecurityClean3.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Bank")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Bik")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CorrespondentAccount")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Inn")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("LegalAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountNumber = "40702810100000000001",
                            Bank = "ПАО Сбербанк",
                            Bik = "044525225",
                            CompanyName = "ООО Рога и копыта",
                            ContactPerson = "Иванов Иван Иванович",
                            CorrespondentAccount = "30101810200000000225",
                            Inn = "770101001",
                            LegalAddress = "123000, г. Москва, ул. Ромашковая, д. 1"
                        },
                        new
                        {
                            Id = 2,
                            AccountNumber = "40702810100000000002",
                            Bank = "ПАО Сбербанк",
                            Bik = "044525225",
                            CompanyName = "ПАО ЖЭК",
                            ContactPerson = "Петров Петр Петрович",
                            CorrespondentAccount = "30101810200000000225",
                            Inn = "770202001",
                            LegalAddress = "123000, г. Москва, ул. Клавишная, д. 2"
                        },
                        new
                        {
                            Id = 3,
                            AccountNumber = "40702810100000000003",
                            Bank = "ПАО Сбербанк",
                            Bik = "044525225",
                            CompanyName = "ООО МикроАванс",
                            ContactPerson = "Сидоров Сидр Сидрович",
                            CorrespondentAccount = "30101810200000000225",
                            Inn = "770303001",
                            LegalAddress = "123000, г. Москва, ул. Ладожская, д. 3"
                        },
                        new
                        {
                            Id = 4,
                            AccountNumber = "40702810100000000004",
                            Bank = "ПАО Сбербанк",
                            Bik = "044525225",
                            CompanyName = "ОАО Гофры",
                            ContactPerson = "Кузнецов Кузьма Кузьмич",
                            CorrespondentAccount = "30101810200000000225",
                            Inn = "770404001",
                            LegalAddress = "123000, г. Москва, ул. Букетиров, д. 4"
                        },
                        new
                        {
                            Id = 5,
                            AccountNumber = "40702810100000000005",
                            Bank = "ПАО Сбербанк",
                            Bik = "044525225",
                            CompanyName = "ООО БК Всех и каждого",
                            ContactPerson = "Лебедев Лев Лебедевич",
                            CorrespondentAccount = "30101810200000000225",
                            Inn = "770505001",
                            LegalAddress = "123000, г. Москва, ул. Галошная, д. 5"
                        });
                });

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

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

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

            modelBuilder.Entity("SecurityClean3.Models.SecuredItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("SecuredItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "ул. Тверская, 1, Москва, Россия",
                            Name = "Банк"
                        },
                        new
                        {
                            Id = 2,
                            Address = "пр. Независимости, 15, Минск, Беларусь",
                            Name = "Ювелирный салон"
                        },
                        new
                        {
                            Id = 3,
                            Address = "ул. Большая Спасская, 24, Санкт-Петербург, Россия",
                            Name = "Автоцентр"
                        },
                        new
                        {
                            Id = 4,
                            Address = "пр. Победителей, 50, Минск, Беларусь",
                            Name = "Музей"
                        },
                        new
                        {
                            Id = 5,
                            Address = "ул. Театральная, 10, Москва, Россия",
                            Name = "Театр"
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SecurityClean3.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SecurityClean3.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecurityClean3.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SecurityClean3.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SecurityClean3.Models.Contract", b =>
                {
                    b.HasOne("SecurityClean3.Models.Customer", "Customer")
                        .WithMany("contracts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SecurityClean3.Models.ContractSecuredItem", b =>
                {
                    b.HasOne("SecurityClean3.Models.Contract", "Contract")
                        .WithMany("ContractSecuredItems")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecurityClean3.Models.SecuredItem", "SecuredItem")
                        .WithMany("ContractSecuredItems")
                        .HasForeignKey("SecuredItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("SecuredItem");
                });

            modelBuilder.Entity("SecurityClean3.Models.ContractService", b =>
                {
                    b.HasOne("SecurityClean3.Models.Contract", "Contract")
                        .WithMany("ContractServices")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecurityClean3.Models.Service", "Service")
                        .WithMany("ContractServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("Service");
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
                        .WithMany("Services")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("SecurityClean3.Models.Contract", b =>
                {
                    b.Navigation("ContractSecuredItems");

                    b.Navigation("ContractServices");
                });

            modelBuilder.Entity("SecurityClean3.Models.Customer", b =>
                {
                    b.Navigation("contracts");
                });

            modelBuilder.Entity("SecurityClean3.Models.Position", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("SecurityClean3.Models.SecuredItem", b =>
                {
                    b.Navigation("ContractSecuredItems");
                });

            modelBuilder.Entity("SecurityClean3.Models.Service", b =>
                {
                    b.Navigation("ContractServices");
                });
#pragma warning restore 612, 618
        }
    }
}
