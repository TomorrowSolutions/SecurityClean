using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecurityClean3.Migrations
{
    /// <inheritdoc />
    public partial class addLocalPathAndDeleteAdminKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "AdminKey",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "LocalPath",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e64e1c7-8a6d-463f-a91d-ca074774a7fb", null, "manager", "manager" },
                    { "59ff4452-2509-4cf9-912c-e671f45708d9", null, "admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2e64e1c7-8a6d-463f-a91d-ca074774a7fb", 0, "3e4467c6-37ad-4bb0-b6bd-9f16c173277e", "manager@mail.com", false, "manager", false, null, "manager@mail.com", "manager@mail.com", "AQAAAAIAAYagAAAAECx/erpKG/z2R8yTUxVHbeLrzdVy0OM9PepPU797ZeG1znP7J9CwWflaTn4jP2YuwA==", null, false, "", false, "manager@mail.com" },
                    { "59ff4452-2509-4cf9-912c-e671f45708d9", 0, "0b97bb8d-8ce7-432f-a9c4-ca09d865ee0a", "admin@mail.com", false, "admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAIAAYagAAAAEMZfQkhvfY7BGBpYYrXcZ3CQhG14l9QnqOcbwqmVq7yxvyybiyd7RVD7vTz97KTjQg==", null, false, "", false, "admin@mail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 1,
                column: "LocalPath",
                value: null);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2e64e1c7-8a6d-463f-a91d-ca074774a7fb", "2e64e1c7-8a6d-463f-a91d-ca074774a7fb" },
                    { "59ff4452-2509-4cf9-912c-e671f45708d9", "59ff4452-2509-4cf9-912c-e671f45708d9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2e64e1c7-8a6d-463f-a91d-ca074774a7fb", "2e64e1c7-8a6d-463f-a91d-ca074774a7fb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "59ff4452-2509-4cf9-912c-e671f45708d9", "59ff4452-2509-4cf9-912c-e671f45708d9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e64e1c7-8a6d-463f-a91d-ca074774a7fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59ff4452-2509-4cf9-912c-e671f45708d9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e64e1c7-8a6d-463f-a91d-ca074774a7fb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59ff4452-2509-4cf9-912c-e671f45708d9");

            migrationBuilder.DropColumn(
                name: "LocalPath",
                table: "Contracts");

            migrationBuilder.AddColumn<string>(
                name: "AdminKey",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cc72d863-ce29-4eb8-a8ff-037296ff8cc0", "cc72d863-ce29-4eb8-a8ff-037296ff8cc0" },
                    { "e6e1c149-da14-49a8-b955-10e7acc9cca2", "e6e1c149-da14-49a8-b955-10e7acc9cca2" }
                });
        }
    }
}
