using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchroniskoPsy.Data.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be896bb8-9ebc-4c2a-9ac2-6f60b1458d6c", "AQAAAAEAACcQAAAAEIHEqeww1TjgaQDaZcWSqIM8clQjn56wWFnkvKDlEgo9wyNUbnvk7OyRJxzaZE4xSg==", "135517a4-6e6b-4525-873d-ddf5a90c0095" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02d889a6-143b-43c8-aa91-ada5b73441f0", "AQAAAAEAACcQAAAAEJyiBbeK8T1JtVU5s3R4KLAYwGtxfisQiOFf7IB06/i327V/JIa+km8UuGNQz6TbFg==", "1d796b79-a4fd-44ba-b2ec-50d4f9c64fd3" });
        }
    }
}
