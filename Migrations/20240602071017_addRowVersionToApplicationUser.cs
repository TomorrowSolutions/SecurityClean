using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecurityClean3.Migrations
{
    /// <inheritdoc />
    public partial class addRowVersionToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AspNetUsers",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a0bc6e3-4579-45f9-9f2a-91600b8d3783", null, "Admin", "Admin" },
                    { "5720e4c6-1329-432c-ad02-51cc31e2669a", null, "Manager", "Manager" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1a0bc6e3-4579-45f9-9f2a-91600b8d3783", 0, "16005a2f-5f5c-4c07-a63c-0f22ca60718d", "admin@mail.com", false, "admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAIAAYagAAAAEIYKtm2tYgafrgQ5wIXReq/y+0La3eqAuqKXADoWdKx6Y0M5TiDlOotXP9DTV2cGUA==", null, false, "", false, "admin@mail.com" },
                    { "5720e4c6-1329-432c-ad02-51cc31e2669a", 0, "08dc8f9d-bef4-412e-b669-02249e781e18", "manager@mail.com", false, "manager", false, null, "manager@mail.com", "manager@mail.com", "AQAAAAIAAYagAAAAEGmc2lO10AK9WXdB0LYwnE+i/vvX4tQP1cHfgYiLmwsRE9HoBcXdpzsiGRcjjWbkCg==", null, false, "", false, "manager@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1a0bc6e3-4579-45f9-9f2a-91600b8d3783", "1a0bc6e3-4579-45f9-9f2a-91600b8d3783" },
                    { "5720e4c6-1329-432c-ad02-51cc31e2669a", "5720e4c6-1329-432c-ad02-51cc31e2669a" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a0bc6e3-4579-45f9-9f2a-91600b8d3783", "1a0bc6e3-4579-45f9-9f2a-91600b8d3783" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5720e4c6-1329-432c-ad02-51cc31e2669a", "5720e4c6-1329-432c-ad02-51cc31e2669a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a0bc6e3-4579-45f9-9f2a-91600b8d3783");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5720e4c6-1329-432c-ad02-51cc31e2669a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a0bc6e3-4579-45f9-9f2a-91600b8d3783");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5720e4c6-1329-432c-ad02-51cc31e2669a");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AspNetUsers");

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
    }
}
