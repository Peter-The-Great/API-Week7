using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planner.Migrations
{
    /// <inheritdoc />
    public partial class _34 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attractie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attractie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gast", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GastId = table.Column<int>(type: "INTEGER", nullable: false),
                    AttractieId = table.Column<int>(type: "INTEGER", nullable: false),
                    Dag = table.Column<int>(type: "INTEGER", nullable: false),
                    DagDeel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservering", x => x.Id);
                    table.CheckConstraint("DagdeelMaximum", "DagDeel <= 35 AND DagDeel >= 0");
                    table.ForeignKey(
                        name: "FK_Reservering_Attractie_AttractieId",
                        column: x => x.AttractieId,
                        principalTable: "Attractie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservering_Gast_GastId",
                        column: x => x.GastId,
                        principalTable: "Gast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attractie_Naam",
                table: "Attractie",
                column: "Naam",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservering_AttractieId",
                table: "Reservering",
                column: "AttractieId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservering_GastId",
                table: "Reservering",
                column: "GastId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservering");

            migrationBuilder.DropTable(
                name: "Attractie");

            migrationBuilder.DropTable(
                name: "Gast");
        }
    }
}
