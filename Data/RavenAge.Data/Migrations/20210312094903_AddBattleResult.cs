using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RavenAge.Data.Migrations
{
    public partial class AddBattleResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gold",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Silver",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stone",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wood",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BattleResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Atacker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Defender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Winner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoneProfit = table.Column<int>(type: "int", nullable: false),
                    WoodProfit = table.Column<int>(type: "int", nullable: false),
                    GoldProfit = table.Column<int>(type: "int", nullable: false),
                    AttackerArchers = table.Column<int>(type: "int", nullable: false),
                    AtackerInfantrys = table.Column<int>(type: "int", nullable: false),
                    AtackerCavalry = table.Column<int>(type: "int", nullable: false),
                    AtackerArtillery = table.Column<int>(type: "int", nullable: false),
                    AttackerArchersLoss = table.Column<int>(type: "int", nullable: false),
                    AtackerInfantrysLoss = table.Column<int>(type: "int", nullable: false),
                    AtackerCavalryLoss = table.Column<int>(type: "int", nullable: false),
                    AtackerArtilleryLoss = table.Column<int>(type: "int", nullable: false),
                    DefenderArchers = table.Column<int>(type: "int", nullable: false),
                    DefenderInfantrys = table.Column<int>(type: "int", nullable: false),
                    DefenderCavalry = table.Column<int>(type: "int", nullable: false),
                    DefenderArtillery = table.Column<int>(type: "int", nullable: false),
                    DefenseWallPoints = table.Column<int>(type: "int", nullable: false),
                    DefenderArchersLoss = table.Column<int>(type: "int", nullable: false),
                    DefenderInfantrysLoss = table.Column<int>(type: "int", nullable: false),
                    DefenderCavalryLoss = table.Column<int>(type: "int", nullable: false),
                    DefenderArtilleryLoss = table.Column<int>(type: "int", nullable: false),
                    DefenseWallPointsLoss = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserBattles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BattleResultId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBattles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBattles_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBattles_BattleResults_BattleResultId",
                        column: x => x.BattleResultId,
                        principalTable: "BattleResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBattles_BattleResultId",
                table: "UserBattles",
                column: "BattleResultId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBattles_UserId1",
                table: "UserBattles",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBattles");

            migrationBuilder.DropTable(
                name: "BattleResults");

            migrationBuilder.DropColumn(
                name: "Gold",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Silver",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Stone",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Wood",
                table: "Cities");
        }
    }
}
