using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecurityClean3.Migrations
{
    /// <inheritdoc />
    public partial class addRowVersionToContract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Contracts",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Contracts");

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
    }
}
