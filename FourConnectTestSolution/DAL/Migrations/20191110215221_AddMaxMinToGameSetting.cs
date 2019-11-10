using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.VisualBasic.CompilerServices;

namespace DAL.Migrations
{
    public partial class AddMaxMinToGameSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxValue",
                table: "GameSettings",
                nullable: false,
                defaultValue: int.MaxValue);

            migrationBuilder.AddColumn<int>(
                name: "MinValue",
                table: "GameSettings",
                nullable: false,
                defaultValue: int.MinValue);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxValue",
                table: "GameSettings");

            migrationBuilder.DropColumn(
                name: "MinValue",
                table: "GameSettings");
        }
    }
}
