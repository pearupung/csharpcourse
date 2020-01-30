using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class PerformerRoleUpdate3Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Djs",
                columns: table => new
                {
                    DjId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Djs", x => x.DjId);
                });

            migrationBuilder.CreateTable(
                name: "PerformerRoles",
                columns: table => new
                {
                    PerformerRoleId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PerformerRoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformerRoles", x => x.PerformerRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Performers",
                columns: table => new
                {
                    PerformerId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performers", x => x.PerformerId);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    TrackId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TrackName = table.Column<string>(nullable: true),
                    TrackLengthInSeconds = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.TrackId);
                    table.ForeignKey(
                        name: "FK_Tracks_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DjTracks",
                columns: table => new
                {
                    DjTrackId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TrackId = table.Column<int>(nullable: false),
                    DjId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DjTracks", x => x.DjTrackId);
                    table.ForeignKey(
                        name: "FK_DjTracks_Djs_DjId",
                        column: x => x.DjId,
                        principalTable: "Djs",
                        principalColumn: "DjId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DjTracks_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerformerTracks",
                columns: table => new
                {
                    PerformerTrackId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PerformerId = table.Column<int>(nullable: false),
                    TrackId = table.Column<int>(nullable: false),
                    PerformerTrackName = table.Column<string>(nullable: true),
                    CostPerSecond = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformerTracks", x => x.PerformerTrackId);
                    table.ForeignKey(
                        name: "FK_PerformerTracks_Performers_PerformerId",
                        column: x => x.PerformerId,
                        principalTable: "Performers",
                        principalColumn: "PerformerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerformerTracks_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerformerTrackRoles",
                columns: table => new
                {
                    PerformerTrackRoleId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PerformerTrackId = table.Column<int>(nullable: false),
                    PerformerRoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformerTrackRoles", x => x.PerformerTrackRoleId);
                    table.ForeignKey(
                        name: "FK_PerformerTrackRoles_PerformerRoles_PerformerRoleId",
                        column: x => x.PerformerRoleId,
                        principalTable: "PerformerRoles",
                        principalColumn: "PerformerRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerformerTrackRoles_PerformerTracks_PerformerTrackId",
                        column: x => x.PerformerTrackId,
                        principalTable: "PerformerTracks",
                        principalColumn: "PerformerTrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DjTracks_DjId",
                table: "DjTracks",
                column: "DjId");

            migrationBuilder.CreateIndex(
                name: "IX_DjTracks_TrackId",
                table: "DjTracks",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformerTrackRoles_PerformerRoleId",
                table: "PerformerTrackRoles",
                column: "PerformerRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformerTrackRoles_PerformerTrackId",
                table: "PerformerTrackRoles",
                column: "PerformerTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformerTracks_PerformerId",
                table: "PerformerTracks",
                column: "PerformerId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformerTracks_TrackId",
                table: "PerformerTracks",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_CategoryId",
                table: "Tracks",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DjTracks");

            migrationBuilder.DropTable(
                name: "PerformerTrackRoles");

            migrationBuilder.DropTable(
                name: "Djs");

            migrationBuilder.DropTable(
                name: "PerformerRoles");

            migrationBuilder.DropTable(
                name: "PerformerTracks");

            migrationBuilder.DropTable(
                name: "Performers");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
