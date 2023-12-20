using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EZLotteri.Migrations
{
    public partial class OpdaterBørneGruppe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Bruger",
                schema: "dbo",
                columns: table => new
                {
                    BrugerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bruger", x => x.BrugerID);
                });

            migrationBuilder.CreateTable(
                name: "Leder",
                schema: "dbo",
                columns: table => new
                {
                    LederID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrugerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leder", x => x.LederID);
                    table.ForeignKey(
                        name: "FK_Leder_Bruger_BrugerID",
                        column: x => x.BrugerID,
                        principalSchema: "dbo",
                        principalTable: "Bruger",
                        principalColumn: "BrugerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BørneGruppe",
                schema: "dbo",
                columns: table => new
                {
                    BørnegruppeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LederID = table.Column<int>(type: "int", nullable: false),
                    AntalUdstedteLodsedler = table.Column<int>(type: "int", nullable: false),
                    AntalReturneredeLodsedler = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BørneGruppe", x => x.BørnegruppeID);
                    table.ForeignKey(
                        name: "FK_BørneGruppe_Leder_LederID",
                        column: x => x.LederID,
                        principalSchema: "dbo",
                        principalTable: "Leder",
                        principalColumn: "LederID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Barn",
                schema: "dbo",
                columns: table => new
                {
                    BarnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LederID = table.Column<int>(type: "int", nullable: false),
                    AntalModtagneLodsedler = table.Column<int>(type: "int", nullable: false),
                    AntalSolgteMobilePay = table.Column<int>(type: "int", nullable: false),
                    AntalSolgteKontanter = table.Column<int>(type: "int", nullable: false),
                    BørnegruppeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barn", x => x.BarnID);
                    table.ForeignKey(
                        name: "FK_Barn_BørneGruppe_BørnegruppeID",
                        column: x => x.BørnegruppeID,
                        principalSchema: "dbo",
                        principalTable: "BørneGruppe",
                        principalColumn: "BørnegruppeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Barn_Leder_LederID",
                        column: x => x.LederID,
                        principalSchema: "dbo",
                        principalTable: "Leder",
                        principalColumn: "LederID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barn_BørnegruppeID",
                schema: "dbo",
                table: "Barn",
                column: "BørnegruppeID");

            migrationBuilder.CreateIndex(
                name: "IX_Barn_LederID",
                schema: "dbo",
                table: "Barn",
                column: "LederID");

            migrationBuilder.CreateIndex(
                name: "IX_BørneGruppe_LederID",
                schema: "dbo",
                table: "BørneGruppe",
                column: "LederID");

            migrationBuilder.CreateIndex(
                name: "IX_Leder_BrugerID",
                schema: "dbo",
                table: "Leder",
                column: "BrugerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barn",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BørneGruppe",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Leder",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Bruger",
                schema: "dbo");
        }
    }
}
