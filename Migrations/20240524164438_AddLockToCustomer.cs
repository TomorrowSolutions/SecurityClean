using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecurityClean3.Migrations
{
    /// <inheritdoc />
    public partial class AddLockToCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0ef073a5-8f79-490d-89ed-ef6d0a5e308c", "0ef073a5-8f79-490d-89ed-ef6d0a5e308c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fa587644-bda6-42bc-ab17-d4d127e8aad7", "fa587644-bda6-42bc-ab17-d4d127e8aad7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ef073a5-8f79-490d-89ed-ef6d0a5e308c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa587644-bda6-42bc-ab17-d4d127e8aad7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0ef073a5-8f79-490d-89ed-ef6d0a5e308c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa587644-bda6-42bc-ab17-d4d127e8aad7");

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Contracts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cc72d863-ce29-4eb8-a8ff-037296ff8cc0", null, "admin", "admin" },
                    { "e6e1c149-da14-49a8-b955-10e7acc9cca2", null, "manager", "manager" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdminKey", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "cc72d863-ce29-4eb8-a8ff-037296ff8cc0", 0, "7fb9d6ee-7465-4299-8bbc-e612c4f1503e", "9219b288-6a5e-4cc4-93c3-e248e36772ed", "admin@mail.com", false, "admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAIAAYagAAAAELbAaSFWhqCbLcWxraXfXeH/ludnA/zNmbX84zDaJG8bkUJCIc2DZqnAt8Ao1KITqw==", null, false, "", false, "admin@mail.com" },
                    { "e6e1c149-da14-49a8-b955-10e7acc9cca2", 0, null, "a32b3345-0508-4ce5-be6e-874f07d34ea0", "manager@mail.com", false, "manager", false, null, "manager@mail.com", "manager@mail.com", "AQAAAAIAAYagAAAAEKkTH7j/AWzy94zz4LEYcgPrHk6TjanUAU9ECSFTEQLTcKWK3PzhIT8teWS00+K2Wg==", null, false, "", false, "manager@mail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsLocked",
                value: false);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cc72d863-ce29-4eb8-a8ff-037296ff8cc0", "cc72d863-ce29-4eb8-a8ff-037296ff8cc0" },
                    { "e6e1c149-da14-49a8-b955-10e7acc9cca2", "e6e1c149-da14-49a8-b955-10e7acc9cca2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc72d863-ce29-4eb8-a8ff-037296ff8cc0", "cc72d863-ce29-4eb8-a8ff-037296ff8cc0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e6e1c149-da14-49a8-b955-10e7acc9cca2", "e6e1c149-da14-49a8-b955-10e7acc9cca2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc72d863-ce29-4eb8-a8ff-037296ff8cc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6e1c149-da14-49a8-b955-10e7acc9cca2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc72d863-ce29-4eb8-a8ff-037296ff8cc0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6e1c149-da14-49a8-b955-10e7acc9cca2");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Contracts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ef073a5-8f79-490d-89ed-ef6d0a5e308c", null, "admin", "admin" },
                    { "fa587644-bda6-42bc-ab17-d4d127e8aad7", null, "manager", "manager" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdminKey", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0ef073a5-8f79-490d-89ed-ef6d0a5e308c", 0, "4811e8e9-3429-48c7-a8c8-01d635c969d1", "562dd8ca-c604-4d57-b545-7d811be390be", "admin@mail.com", false, "admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAIAAYagAAAAECDoCzhUdjesRfj/RrwSvKGdfPL4gqsY+xtFD3fB1qArBbcq5c4Az9R9iS2wus3ing==", null, false, "", false, "admin@mail.com" },
                    { "fa587644-bda6-42bc-ab17-d4d127e8aad7", 0, null, "02d578af-efc0-42ad-a176-575509dcef08", "manager@mail.com", false, "manager", false, null, "manager@mail.com", "manager@mail.com", "AQAAAAIAAYagAAAAEOejxVzQvCE1BA5KgPJHAiHscqcu+wBLhx4P9rxmau0MXj2pfHzPxFeJRcl2zR6J8g==", null, false, "", false, "manager@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0ef073a5-8f79-490d-89ed-ef6d0a5e308c", "0ef073a5-8f79-490d-89ed-ef6d0a5e308c" },
                    { "fa587644-bda6-42bc-ab17-d4d127e8aad7", "fa587644-bda6-42bc-ab17-d4d127e8aad7" }
                });
        }
    }
}
