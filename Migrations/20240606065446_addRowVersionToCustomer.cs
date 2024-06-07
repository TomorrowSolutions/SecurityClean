using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecurityClean3.Migrations
{
    /// <inheritdoc />
    public partial class addRowVersionToCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4800cf27-4ba0-4976-b7cd-e891b2f045a7", "4800cf27-4ba0-4976-b7cd-e891b2f045a7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e8034602-99e0-4c26-bc7c-bf418dc7cc63", "e8034602-99e0-4c26-bc7c-bf418dc7cc63" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4800cf27-4ba0-4976-b7cd-e891b2f045a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8034602-99e0-4c26-bc7c-bf418dc7cc63");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4800cf27-4ba0-4976-b7cd-e891b2f045a7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e8034602-99e0-4c26-bc7c-bf418dc7cc63");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Customers",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "87f9d577-a8a3-4a11-be54-9d9419703526", null, "Admin", "Admin" },
                    { "8889c4ce-4fd6-48c8-b952-04df3829b1fb", null, "Manager", "Manager" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "87f9d577-a8a3-4a11-be54-9d9419703526", 0, "dfc641af-5baa-44df-bf6f-deb86f66fc5d", "admin@mail.com", false, "admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAIAAYagAAAAEGhKlOwljh/RKxOqEiEa0GznhY1ErEoxBQMIRlwS2xwnMOY/6l9An1Pw6WJtDrRxxw==", null, false, "", false, "admin@mail.com" },
                    { "8889c4ce-4fd6-48c8-b952-04df3829b1fb", 0, "3aa5f59e-ea37-40dd-9c52-6f7d1de8f524", "manager@mail.com", false, "manager", false, null, "manager@mail.com", "manager@mail.com", "AQAAAAIAAYagAAAAEOW5+Zz8bMQdTfg3USkIp8zrvfeyUDwjBBoKkmUk8F1/pTvhaS/ej7rSIYKVMhZOiw==", null, false, "", false, "manager@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "87f9d577-a8a3-4a11-be54-9d9419703526", "87f9d577-a8a3-4a11-be54-9d9419703526" },
                    { "8889c4ce-4fd6-48c8-b952-04df3829b1fb", "8889c4ce-4fd6-48c8-b952-04df3829b1fb" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "87f9d577-a8a3-4a11-be54-9d9419703526", "87f9d577-a8a3-4a11-be54-9d9419703526" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8889c4ce-4fd6-48c8-b952-04df3829b1fb", "8889c4ce-4fd6-48c8-b952-04df3829b1fb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87f9d577-a8a3-4a11-be54-9d9419703526");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8889c4ce-4fd6-48c8-b952-04df3829b1fb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "87f9d577-a8a3-4a11-be54-9d9419703526");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8889c4ce-4fd6-48c8-b952-04df3829b1fb");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4800cf27-4ba0-4976-b7cd-e891b2f045a7", null, "Manager", "Manager" },
                    { "e8034602-99e0-4c26-bc7c-bf418dc7cc63", null, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4800cf27-4ba0-4976-b7cd-e891b2f045a7", 0, "6e285534-6268-4876-87a5-6a108d8c7d8f", "manager@mail.com", false, "manager", false, null, "manager@mail.com", "manager@mail.com", "AQAAAAIAAYagAAAAEKlHaY4u4IEJn/N7RAJDzapqq1dMhVrPz5oWJsC/lVTHK1KAqV3Wb2FcUT7A0GF5zg==", null, false, "", false, "manager@mail.com" },
                    { "e8034602-99e0-4c26-bc7c-bf418dc7cc63", 0, "acf2dfd2-df85-47fb-86b1-21f3f0141d70", "admin@mail.com", false, "admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAIAAYagAAAAEFlDW25/1PRIx9eSfZ6hnq/z2bRZ9LYJcJaafEHaVxlODJORtA1e7Q4RoiOQXagclw==", null, false, "", false, "admin@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4800cf27-4ba0-4976-b7cd-e891b2f045a7", "4800cf27-4ba0-4976-b7cd-e891b2f045a7" },
                    { "e8034602-99e0-4c26-bc7c-bf418dc7cc63", "e8034602-99e0-4c26-bc7c-bf418dc7cc63" }
                });
        }
    }
}
