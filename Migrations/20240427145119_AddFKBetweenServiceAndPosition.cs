using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecurityClean3.Migrations
{
    /// <inheritdoc />
    public partial class AddFKBetweenServiceAndPosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Охранник");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Телохранитель");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Водитель");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "PositionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "PositionId" },
                values: new object[] { "Обслуживание системы видеонаблюдения", 5 });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "PositionId" },
                values: new object[] { "Перевозка грузов", 4 });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "PositionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "PositionId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Services_PositionId",
                table: "Services",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Positions_PositionId",
                table: "Services",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Positions_PositionId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_PositionId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Services");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Охранник без лицензии на оружие");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Охранник c лицензией на оружие");

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Менеджер по связям с общественностью");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Установка системы контроля доступа");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Установка системы обнаружения взлома");
        }
    }
}
