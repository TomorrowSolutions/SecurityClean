using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecurityClean3.Migrations
{
    /// <inheritdoc />
    public partial class changeApplicationUserFullNameNullableFalse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6a0b6fcd-ddd4-458e-bc35-7b47326e517b", "6a0b6fcd-ddd4-458e-bc35-7b47326e517b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ca39ab0b-f64f-4b4b-8b83-f9fbed42f4d8", "ca39ab0b-f64f-4b4b-8b83-f9fbed42f4d8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a0b6fcd-ddd4-458e-bc35-7b47326e517b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca39ab0b-f64f-4b4b-8b83-f9fbed42f4d8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a0b6fcd-ddd4-458e-bc35-7b47326e517b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca39ab0b-f64f-4b4b-8b83-f9fbed42f4d8");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "94a89c19-766c-4e4e-94de-e21ab94b9251", null, "Admin", "Admin" },
                    { "f3966825-4f64-4ef0-ab25-ecc4b0fd3679", null, "Manager", "Manager" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "94a89c19-766c-4e4e-94de-e21ab94b9251", 0, "97388968-6764-40ad-b04f-439b8a1dab19", "admin@mail.com", false, "admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAIAAYagAAAAEEWMRtVF67DVarbrkaIy0+NIrzegGmqqS6J9+aONUt64LhA9wMEJgn/I8Wi6KuYHrQ==", null, false, "", false, "admin@mail.com" },
                    { "f3966825-4f64-4ef0-ab25-ecc4b0fd3679", 0, "9b000709-fb41-4fbd-af3c-8d18cc8d1ad3", "manager@mail.com", false, "manager", false, null, "manager@mail.com", "manager@mail.com", "AQAAAAIAAYagAAAAEIIIXJlm679BnOICgWCV/l4WflUzSCvQx+/u1Hi382QeTYvDbp/D2/tOCXwgczh4Fg==", null, false, "", false, "manager@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "94a89c19-766c-4e4e-94de-e21ab94b9251", "94a89c19-766c-4e4e-94de-e21ab94b9251" },
                    { "f3966825-4f64-4ef0-ab25-ecc4b0fd3679", "f3966825-4f64-4ef0-ab25-ecc4b0fd3679" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "94a89c19-766c-4e4e-94de-e21ab94b9251", "94a89c19-766c-4e4e-94de-e21ab94b9251" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f3966825-4f64-4ef0-ab25-ecc4b0fd3679", "f3966825-4f64-4ef0-ab25-ecc4b0fd3679" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a89c19-766c-4e4e-94de-e21ab94b9251");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3966825-4f64-4ef0-ab25-ecc4b0fd3679");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "94a89c19-766c-4e4e-94de-e21ab94b9251");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3966825-4f64-4ef0-ab25-ecc4b0fd3679");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6a0b6fcd-ddd4-458e-bc35-7b47326e517b", null, "Manager", "Manager" },
                    { "ca39ab0b-f64f-4b4b-8b83-f9fbed42f4d8", null, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6a0b6fcd-ddd4-458e-bc35-7b47326e517b", 0, "cc7b1092-5a71-4aed-83af-f562d4ed69cb", "manager@mail.com", false, "manager", false, null, "manager@mail.com", "manager@mail.com", "AQAAAAIAAYagAAAAEBQo3JzYqrhAVCYNplBwEFVNUGKclBIBTMbVslvA94SPsHwlVaTmqcopaWmWkZKdRA==", null, false, "", false, "manager@mail.com" },
                    { "ca39ab0b-f64f-4b4b-8b83-f9fbed42f4d8", 0, "b2c07578-5633-4447-ac5f-14c18f6c3d0e", "admin@mail.com", false, "admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAIAAYagAAAAECjBeP6BpGBiTH5//K9JjEzE1Jx25M7lloVl4We9mUkqIvS52aLcqjNKiATOO++LDg==", null, false, "", false, "admin@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "6a0b6fcd-ddd4-458e-bc35-7b47326e517b", "6a0b6fcd-ddd4-458e-bc35-7b47326e517b" },
                    { "ca39ab0b-f64f-4b4b-8b83-f9fbed42f4d8", "ca39ab0b-f64f-4b4b-8b83-f9fbed42f4d8" }
                });
        }
    }
}
