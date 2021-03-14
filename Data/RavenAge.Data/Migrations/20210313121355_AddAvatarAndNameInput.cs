using Microsoft.EntityFrameworkCore.Migrations;

namespace RavenAge.Data.Migrations
{
    public partial class AddAvatarAndNameInput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DefenceRune",
                table: "AspNetUsers",
                newName: "HealthRune");

            migrationBuilder.RenameColumn(
                name: "ArmyRune",
                table: "AspNetUsers",
                newName: "DefenseRune");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Premium",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Premium",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "HealthRune",
                table: "AspNetUsers",
                newName: "DefenceRune");

            migrationBuilder.RenameColumn(
                name: "DefenseRune",
                table: "AspNetUsers",
                newName: "ArmyRune");
        }
    }
}
