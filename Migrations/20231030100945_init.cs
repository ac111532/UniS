using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniS.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a127d843-2b89-407e-b47b-693c261c5b6b", "07839ff0-9e60-41f2-8d5e-323361f7a506" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a9cd2d1d-e9ff-4420-90c0-43ccfdfd4f19", "d68332da-0345-4160-a7fb-1cc9897cbfb0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a127d843-2b89-407e-b47b-693c261c5b6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9cd2d1d-e9ff-4420-90c0-43ccfdfd4f19");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "07839ff0-9e60-41f2-8d5e-323361f7a506");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d68332da-0345-4160-a7fb-1cc9897cbfb0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "239441ac-c2db-4746-868e-8688d30f186f", "40846746-4701-457f-886c-3d06da8f1277", "Admin", "ADMIN" },
                    { "53e16fff-3e92-4a87-8113-d5c1dc645baa", "cc6a444c-3730-40ee-8c71-c2e46073a0c5", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CustomerAddress", "CustomerFirstName", "CustomerLastName", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2a610fd1-9c3d-4d4e-93f6-f4994bef1017", 0, "df8f6433-6a07-4158-b2ff-4a7f92ea7c98", "School", "Admin", "Account", "Customer", "admin@avcol.school.nz", true, false, null, "ADMIN@AVCOL.SCHOOL.NZ", "ADMIN@AVCOL.SCHOOL.NZ", "AQAAAAEAACcQAAAAEJJM9CWa19/Wscnte0dtNx26FYk+RafMN4e5xx9lGYd3lomUCDdxSkfIUNyZSKVXVQ==", null, false, "e78445e4-2126-42ed-8f8d-6e57578b6f95", false, "admin@avcol.school.nz" },
                    { "d22d00da-a91e-4141-b8f1-fbae980612a1", 0, "10e8372a-ec5b-4ea2-b9b5-923dd2c8cf08", "Home", "Customer", "Account", "Customer", "testcustomer@gmail.com", true, false, null, "TESTCUSTOMER@GMAIL.COM", "TESTCUSTOMER@GMAIL.COM", "AQAAAAEAACcQAAAAEDDZL2KRd0FAZrGa/yaNCZgqUBnCuhGny2b5MsYG/zyi0rZ8XvwW0j2BAZaaQ8dtRQ==", null, false, "9fae21c6-36fd-41a2-9941-87998eb5de67", false, "testcustomer@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "239441ac-c2db-4746-868e-8688d30f186f", "2a610fd1-9c3d-4d4e-93f6-f4994bef1017" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "53e16fff-3e92-4a87-8113-d5c1dc645baa", "d22d00da-a91e-4141-b8f1-fbae980612a1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "239441ac-c2db-4746-868e-8688d30f186f", "2a610fd1-9c3d-4d4e-93f6-f4994bef1017" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "53e16fff-3e92-4a87-8113-d5c1dc645baa", "d22d00da-a91e-4141-b8f1-fbae980612a1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "239441ac-c2db-4746-868e-8688d30f186f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53e16fff-3e92-4a87-8113-d5c1dc645baa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a610fd1-9c3d-4d4e-93f6-f4994bef1017");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d22d00da-a91e-4141-b8f1-fbae980612a1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a127d843-2b89-407e-b47b-693c261c5b6b", "61fdce04-cdd8-4e63-8a30-c426c9e7a7a3", "Admin", "ADMIN" },
                    { "a9cd2d1d-e9ff-4420-90c0-43ccfdfd4f19", "14bebbd4-3845-4259-8fc9-333f331d02ab", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CustomerAddress", "CustomerFirstName", "CustomerLastName", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "07839ff0-9e60-41f2-8d5e-323361f7a506", 0, "e56cffee-2257-4eb9-a3d7-77ff5fe58b2e", "School", "Admin", "Account", "Customer", "admin@avcol.school.nz", true, false, null, "ADMIN@AVCOL.SCHOOL.NZ", "ADMIN@AVCOL.SCHOOL.NZ", "AQAAAAEAACcQAAAAEBp57Sy8Dn2PkqkMRuO+HtTu2mBrRsPDRa1DpmIeTFJpLl4KWiU2EjbxduQqpqa5KA==", null, false, "f1a39ef3-3b05-40c5-a7fb-c2f17ad67055", false, "admin@avcol.school.nz" },
                    { "d68332da-0345-4160-a7fb-1cc9897cbfb0", 0, "7bd0b606-64fd-4aae-8e2c-19993b208702", "Home", "Customer", "Account", "Customer", "testcustomer@gmail.com", true, false, null, "TESTCUSTOMER@GMAIL.COM", "TESTCUSTOMER@GMAIL.COM", "AQAAAAEAACcQAAAAECyP4qPW2iPISx0DxVElVgJVi4lkHVoNq/RlgbGUWiQ6ajiVCK5MycsMu+eMFlPx1g==", null, false, "9ffba7b9-93f1-4622-8d79-9f531b4120c1", false, "testcustomer@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a127d843-2b89-407e-b47b-693c261c5b6b", "07839ff0-9e60-41f2-8d5e-323361f7a506" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a9cd2d1d-e9ff-4420-90c0-43ccfdfd4f19", "d68332da-0345-4160-a7fb-1cc9897cbfb0" });
        }
    }
}
