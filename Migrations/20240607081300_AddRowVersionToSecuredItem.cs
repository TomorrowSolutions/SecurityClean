using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecurityClean3.Migrations
{
    /// <inheritdoc />
    public partial class AddRowVersionToSecuredItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SecuredItems",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a490d57-30c7-432a-86f5-43ecec4acc08", null, "Manager", "Manager" },
                    { "9f7d3436-1e21-4994-82fa-8195058f287b", null, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3a490d57-30c7-432a-86f5-43ecec4acc08", 0, "7a925047-ee9a-4a2a-81bd-234732aa1cda", "manager@mail.com", false, "manager", false, null, "manager@mail.com", "manager@mail.com", "AQAAAAIAAYagAAAAEJf//S6fzW0hKtdGVWt8862im3lcK8CgDV+iUU/NaGU3U64FDd+bjYxEICnt+uB3LA==", null, false, "", false, "manager@mail.com" },
                    { "9f7d3436-1e21-4994-82fa-8195058f287b", 0, "a47e3a78-e9d3-4f51-ac99-a4dc28c9d0c5", "admin@mail.com", false, "admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAIAAYagAAAAEHV90M3S8BCoudgh3AC/950rn1mDJahJ8oJ28Ak0+HB9lw9MjXeNkGASIQ669crnrA==", null, false, "", false, "admin@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3a490d57-30c7-432a-86f5-43ecec4acc08", "3a490d57-30c7-432a-86f5-43ecec4acc08" },
                    { "9f7d3436-1e21-4994-82fa-8195058f287b", "9f7d3436-1e21-4994-82fa-8195058f287b" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3a490d57-30c7-432a-86f5-43ecec4acc08", "3a490d57-30c7-432a-86f5-43ecec4acc08" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9f7d3436-1e21-4994-82fa-8195058f287b", "9f7d3436-1e21-4994-82fa-8195058f287b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a490d57-30c7-432a-86f5-43ecec4acc08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f7d3436-1e21-4994-82fa-8195058f287b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a490d57-30c7-432a-86f5-43ecec4acc08");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f7d3436-1e21-4994-82fa-8195058f287b");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SecuredItems");

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
    }
}
