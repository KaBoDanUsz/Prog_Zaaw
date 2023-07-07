using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchroniskoPsy.Data.Migrations
{
    public partial class finalchyba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "02d889a6-143b-43c8-aa91-ada5b73441f0", "admin@test.test", "ADMIN@TEST.TEST", "AQAAAAEAACcQAAAAEJyiBbeK8T1JtVU5s3R4KLAYwGtxfisQiOFf7IB06/i327V/JIa+km8UuGNQz6TbFg==", "1d796b79-a4fd-44ba-b2ec-50d4f9c64fd3", "admin@test.test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "992ec745-7ffe-4308-9f0b-454cbb8d8a89", "admin@admin.admin", "ADMIN@ADMIN.ADMIN", "AQAAAAEAACcQAAAAEBJ+ZmQ9jdgch8ZS5kLUMrcyjartLRWu5qpOMGgbOjgYkiC6edG9EF7mp9wQYKQQtA==", "f465ebcb-e843-4125-bcfa-a15e0c3f832b", "admin@admin.admin" });
        }
    }
}
