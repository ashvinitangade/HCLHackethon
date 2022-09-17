using Microsoft.EntityFrameworkCore.Migrations;

namespace SharpGaming.Migrations
{
    public partial class AddMarket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EachWay",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numerator = table.Column<int>(type: "int", nullable: false),
                    denominator = table.Column<int>(type: "int", nullable: false),
                    places = table.Column<int>(type: "int", nullable: false),
                    enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EachWay", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RacingInfo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    allowBog = table.Column<bool>(type: "bit", nullable: false),
                    allowSP = table.Column<bool>(type: "bit", nullable: false),
                    onlySP = table.Column<bool>(type: "bit", nullable: false),
                    priceType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacingInfo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    eventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marketId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    marketName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    marketTranslation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eachWayid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.eventId);
                    table.ForeignKey(
                        name: "FK_Markets_EachWay_eachWayid",
                        column: x => x.eachWayid,
                        principalTable: "EachWay",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Selections",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    @decimal = table.Column<string>(name: "decimal", type: "nvarchar(max)", nullable: true),
                    fraction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    american = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    frozen = table.Column<bool>(type: "bit", nullable: false),
                    selectionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    selectionName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    selectionNameTranslation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    selectionNameTranslation2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numerator = table.Column<int>(type: "int", nullable: false),
                    denominator = table.Column<int>(type: "int", nullable: false),
                    eachWayid = table.Column<int>(type: "int", nullable: true),
                    racingInfoid = table.Column<int>(type: "int", nullable: true),
                    participantId = table.Column<int>(type: "int", nullable: false),
                    MarketeventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selections", x => x.id);
                    table.ForeignKey(
                        name: "FK_Selections_EachWay_eachWayid",
                        column: x => x.eachWayid,
                        principalTable: "EachWay",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Selections_Markets_MarketeventId",
                        column: x => x.MarketeventId,
                        principalTable: "Markets",
                        principalColumn: "eventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Selections_RacingInfo_racingInfoid",
                        column: x => x.racingInfoid,
                        principalTable: "RacingInfo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Markets_eachWayid",
                table: "Markets",
                column: "eachWayid");

            migrationBuilder.CreateIndex(
                name: "IX_Selections_eachWayid",
                table: "Selections",
                column: "eachWayid");

            migrationBuilder.CreateIndex(
                name: "IX_Selections_MarketeventId",
                table: "Selections",
                column: "MarketeventId");

            migrationBuilder.CreateIndex(
                name: "IX_Selections_racingInfoid",
                table: "Selections",
                column: "racingInfoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Selections");

            migrationBuilder.DropTable(
                name: "Markets");

            migrationBuilder.DropTable(
                name: "RacingInfo");

            migrationBuilder.DropTable(
                name: "EachWay");
        }
    }
}
