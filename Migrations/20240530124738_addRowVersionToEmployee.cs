using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecurityClean3.Migrations
{
    /// <inheritdoc />
    public partial class addRowVersionToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4797898f-a293-4d99-85ba-e80a4309d59a", "4797898f-a293-4d99-85ba-e80a4309d59a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "918fe4c8-21a0-429c-bc6c-cdebcabd6c88", "918fe4c8-21a0-429c-bc6c-cdebcabd6c88" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4797898f-a293-4d99-85ba-e80a4309d59a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "918fe4c8-21a0-429c-bc6c-cdebcabd6c88");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4797898f-a293-4d99-85ba-e80a4309d59a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "918fe4c8-21a0-429c-bc6c-cdebcabd6c88");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Employees",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4797898f-a293-4d99-85ba-e80a4309d59a", null, "admin", "admin" },
                    { "918fe4c8-21a0-429c-bc6c-cdebcabd6c88", null, "manager", "manager" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4797898f-a293-4d99-85ba-e80a4309d59a", 0, "85b45797-79d6-4b67-bc0b-9045f5048a9b", "admin@mail.com", false, "admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAIAAYagAAAAEA6FrXet9n0Lldy642wRfkhjftQylqTlidPphgIVo885KZMSdPeiWvHxi76P5S3qTw==", null, false, "", false, "admin@mail.com" },
                    { "918fe4c8-21a0-429c-bc6c-cdebcabd6c88", 0, "6270d9a6-6dfd-4de9-a376-4cec92be86b3", "manager@mail.com", false, "manager", false, null, "manager@mail.com", "manager@mail.com", "AQAAAAIAAYagAAAAEID5TECatzeiszCX9upY0tjRzmoxP2vELrOTrl/eSo9jYLBOiWiZbn0qgOoxol7Eyg==", null, false, "", false, "manager@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4797898f-a293-4d99-85ba-e80a4309d59a", "4797898f-a293-4d99-85ba-e80a4309d59a" },
                    { "918fe4c8-21a0-429c-bc6c-cdebcabd6c88", "918fe4c8-21a0-429c-bc6c-cdebcabd6c88" }
                });
        }
    }
}
