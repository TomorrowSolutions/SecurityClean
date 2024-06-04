using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecurityClean3.Migrations
{
    /// <inheritdoc />
    public partial class addRowVersionToServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "05618107-096b-447d-8758-0c68063cb111", "05618107-096b-447d-8758-0c68063cb111" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c5701cbc-97c5-4748-9036-c8d7c074375f", "c5701cbc-97c5-4748-9036-c8d7c074375f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05618107-096b-447d-8758-0c68063cb111");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5701cbc-97c5-4748-9036-c8d7c074375f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "05618107-096b-447d-8758-0c68063cb111");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5701cbc-97c5-4748-9036-c8d7c074375f");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Services",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0105f972-63c8-4d1b-83b5-7006f90a9499", null, "admin", "admin" },
                    { "8fad883a-cd3b-4ed8-ae3a-d7f56e6b61cf", null, "manager", "manager" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0105f972-63c8-4d1b-83b5-7006f90a9499", 0, "6b5f513d-53e8-4db4-b052-37a5768ce1b5", "admin@mail.com", false, "admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAIAAYagAAAAEC9Iv7ttIexMBqgJFCin/Qz3TG0R2UkkTO4jznExrr3L45AgqV4sBil/HNj1FfeOww==", null, false, "", false, "admin@mail.com" },
                    { "8fad883a-cd3b-4ed8-ae3a-d7f56e6b61cf", 0, "261b7d37-18f7-42aa-ac95-06870e150ca3", "manager@mail.com", false, "manager", false, null, "manager@mail.com", "manager@mail.com", "AQAAAAIAAYagAAAAEGjGSI+QOQOQJ9SD4ZSuLUCF9vT6zSyqd8evRRVHVnOBKQE+NlBvH59zmlHrZcL1hw==", null, false, "", false, "manager@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0105f972-63c8-4d1b-83b5-7006f90a9499", "0105f972-63c8-4d1b-83b5-7006f90a9499" },
                    { "8fad883a-cd3b-4ed8-ae3a-d7f56e6b61cf", "8fad883a-cd3b-4ed8-ae3a-d7f56e6b61cf" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0105f972-63c8-4d1b-83b5-7006f90a9499", "0105f972-63c8-4d1b-83b5-7006f90a9499" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8fad883a-cd3b-4ed8-ae3a-d7f56e6b61cf", "8fad883a-cd3b-4ed8-ae3a-d7f56e6b61cf" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0105f972-63c8-4d1b-83b5-7006f90a9499");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fad883a-cd3b-4ed8-ae3a-d7f56e6b61cf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0105f972-63c8-4d1b-83b5-7006f90a9499");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8fad883a-cd3b-4ed8-ae3a-d7f56e6b61cf");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Services");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05618107-096b-447d-8758-0c68063cb111", null, "manager", "manager" },
                    { "c5701cbc-97c5-4748-9036-c8d7c074375f", null, "admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "05618107-096b-447d-8758-0c68063cb111", 0, "15edc2ef-8bc2-4305-a8a5-4c3b26935e7f", "manager@mail.com", false, "manager", false, null, "manager@mail.com", "manager@mail.com", "AQAAAAIAAYagAAAAEGrgn4m7aJEEOQu1Y8e5D3fE2kyuSLBv3IARgPiKQvU+MmfR5gsU/YPOoTE5A8fqpA==", null, false, "", false, "manager@mail.com" },
                    { "c5701cbc-97c5-4748-9036-c8d7c074375f", 0, "8d4fedef-4655-4689-a6f8-910fc459d730", "admin@mail.com", false, "admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAIAAYagAAAAEGAB3y5/9qyp6UmfoJDyC0+00WWzitXUBURNy9InGDuyKlVkUgCVAEunJqukQPbmXQ==", null, false, "", false, "admin@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "05618107-096b-447d-8758-0c68063cb111", "05618107-096b-447d-8758-0c68063cb111" },
                    { "c5701cbc-97c5-4748-9036-c8d7c074375f", "c5701cbc-97c5-4748-9036-c8d7c074375f" }
                });
        }
    }
}
