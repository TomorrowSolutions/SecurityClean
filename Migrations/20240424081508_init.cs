using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecurityClean3.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name", "Wage" },
                values: new object[,]
                {
                    { 1, "Специалист по монтированию", 26000.0 },
                    { 2, "Охранник без лицензии на оружие", 35000.0 },
                    { 3, "Охранник c лицензией на оружие", 75000.0 },
                    { 4, "Менеджер по связям с общественностью", 30000.0 },
                    { 5, "Системный администратор", 32500.0 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Education", "FullName", "HireDate", "PositionId" },
                values: new object[,]
                {
                    { 1, "Среднее профессиональное образование, специальность Охранник", "Иванов Иван Иванович", new DateTime(2018, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, "Высшее образование, специальность Экономист", "Петрова Елена Сергеевна", new DateTime(2019, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 3, "Среднее общее образование", "Сидоров Александр Николаевич", new DateTime(2020, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, "Высшее образование, специальность 'Компьютерные науки и технологии'", "Кузнецова Наталья Владимировна", new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 5, "Среднее профессиональное образование, специальность Охранник", "Михайлов Михаил Алексеевич", new DateTime(2021, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
