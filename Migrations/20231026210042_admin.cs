using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniS.Migrations
{
    public partial class admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
