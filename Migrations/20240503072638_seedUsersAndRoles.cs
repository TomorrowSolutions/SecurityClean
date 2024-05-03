using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecurityClean3.Migrations
{
    /// <inheritdoc />
    public partial class seedUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c28b08c-a4be-4e37-8aac-33982c6130e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71346133-5ff6-4b09-bdd3-8261dc5b95df");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "425decee-d0b3-44ec-9198-970857068e37", null, "admin", "admin" },
                    { "9fbdfde7-35ef-44f0-950e-497530515938", null, "manager", "manager" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdminKey", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "425decee-d0b3-44ec-9198-970857068e37", 0, "605a5681-2f3a-484c-b47c-7760e328e740", "a26ca762-2807-4470-8a9c-ee9ee558066f", "admin@mail.com", false, "admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAIAAYagAAAAEBRkzuJXVnzWA31kKEMFMN8vP7SGlbhuqXSph2LPNtdfSX8Exku6kkz3+kPFiR+3mA==", null, false, "", false, "admin@mail.com" },
                    { "9fbdfde7-35ef-44f0-950e-497530515938", 0, null, "632620c9-b00f-481d-bc6f-f32b151c64d0", "manager@mail.com", false, "manager", false, null, "manager@mail.com", "manager@mail.com", "AQAAAAIAAYagAAAAENsovHdNxZA89W0gWp6iX8GmXqVHr9ps+iu0qB441FP9OTKkmVUFKDg/ssFa6X5BjA==", null, false, "", false, "manager@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "425decee-d0b3-44ec-9198-970857068e37", "425decee-d0b3-44ec-9198-970857068e37" },
                    { "9fbdfde7-35ef-44f0-950e-497530515938", "9fbdfde7-35ef-44f0-950e-497530515938" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "425decee-d0b3-44ec-9198-970857068e37", "425decee-d0b3-44ec-9198-970857068e37" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9fbdfde7-35ef-44f0-950e-497530515938", "9fbdfde7-35ef-44f0-950e-497530515938" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "425decee-d0b3-44ec-9198-970857068e37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fbdfde7-35ef-44f0-950e-497530515938");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "425decee-d0b3-44ec-9198-970857068e37");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9fbdfde7-35ef-44f0-950e-497530515938");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6c28b08c-a4be-4e37-8aac-33982c6130e7", null, "manager", "manager" },
                    { "71346133-5ff6-4b09-bdd3-8261dc5b95df", null, "admin", "admin" }
                });
        }
    }
}
