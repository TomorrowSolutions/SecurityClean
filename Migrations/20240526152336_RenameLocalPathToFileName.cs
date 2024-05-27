using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecurityClean3.Migrations
{
    /// <inheritdoc />
    public partial class RenameLocalPathToFileName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "LocalPath",
                table: "Contracts",
                newName: "FileName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a26a9e76-a06d-40a6-b84a-4fec3a741ca2", null, "admin", "admin" },
                    { "dc4ccf47-776f-4cc0-99cb-01572e53efd7", null, "manager", "manager" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a26a9e76-a06d-40a6-b84a-4fec3a741ca2", 0, "88f4e83b-ee62-43fd-92eb-2c379e16bec3", "admin@mail.com", false, "admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAIAAYagAAAAEInyeBPwUk3TB9EoPknAqnrQonyYs2wwi+UcPzCMRPj1NOj4d0kl6kBZ5czS2ayAKQ==", null, false, "", false, "admin@mail.com" },
                    { "dc4ccf47-776f-4cc0-99cb-01572e53efd7", 0, "0e72f3a2-9582-4070-8bf1-f5916d8cb3f0", "manager@mail.com", false, "manager", false, null, "manager@mail.com", "manager@mail.com", "AQAAAAIAAYagAAAAEO8G2wqlCNpWITdZMYTjta2VV1TmhQRDmXW1zmTOqs5alrlvD5q+kTt7WKmFgwvv2g==", null, false, "", false, "manager@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a26a9e76-a06d-40a6-b84a-4fec3a741ca2", "a26a9e76-a06d-40a6-b84a-4fec3a741ca2" },
                    { "dc4ccf47-776f-4cc0-99cb-01572e53efd7", "dc4ccf47-776f-4cc0-99cb-01572e53efd7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a26a9e76-a06d-40a6-b84a-4fec3a741ca2", "a26a9e76-a06d-40a6-b84a-4fec3a741ca2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dc4ccf47-776f-4cc0-99cb-01572e53efd7", "dc4ccf47-776f-4cc0-99cb-01572e53efd7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a26a9e76-a06d-40a6-b84a-4fec3a741ca2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc4ccf47-776f-4cc0-99cb-01572e53efd7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a26a9e76-a06d-40a6-b84a-4fec3a741ca2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dc4ccf47-776f-4cc0-99cb-01572e53efd7");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Contracts",
                newName: "LocalPath");

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2e64e1c7-8a6d-463f-a91d-ca074774a7fb", "2e64e1c7-8a6d-463f-a91d-ca074774a7fb" },
                    { "59ff4452-2509-4cf9-912c-e671f45708d9", "59ff4452-2509-4cf9-912c-e671f45708d9" }
                });
        }
    }
}
