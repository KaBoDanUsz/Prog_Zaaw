using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchroniskoPsy.Data.Migrations
{
    public partial class koniec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schronisko",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miejscowosc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumerTel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schronisko", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Psy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wiek = table.Column<int>(type: "int", nullable: false),
                    Charakter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rasa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchroniskoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Psy_Schronisko_SchroniskoID",
                        column: x => x.SchroniskoID,
                        principalTable: "Schronisko",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Psy_SchroniskoID",
                table: "Psy",
                column: "SchroniskoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Psy");

            migrationBuilder.DropTable(
                name: "Schronisko");
        }
    }
}
