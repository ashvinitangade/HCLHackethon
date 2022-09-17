using Microsoft.EntityFrameworkCore.Migrations;

namespace SharpGaming.Migrations
{
    public partial class AddTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    home = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    homeTranslation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    away = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    awayTranslation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sportId = table.Column<int>(type: "int", nullable: false),
                    countryId = table.Column<int>(type: "int", nullable: false),
                    tournamentId = table.Column<int>(type: "int", nullable: false),
                    dateStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isLive = table.Column<bool>(type: "bit", nullable: false),
                    isRacingEvent = table.Column<bool>(type: "bit", nullable: false),
                    teamsid = table.Column<int>(type: "int", nullable: true),
                    outright = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.id);
                    table.ForeignKey(
                        name: "FK_Events_Teams_teamsid",
                        column: x => x.teamsid,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_teamsid",
                table: "Events",
                column: "teamsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
