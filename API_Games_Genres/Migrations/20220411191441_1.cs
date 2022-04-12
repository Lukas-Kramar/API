using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Games_Genres.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MembersCount = table.Column<int>(type: "int", nullable: false),
                    MoneyWon = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartedPlaying = table.Column<int>(type: "int", nullable: false),
                    MoneyWon = table.Column<int>(type: "int", nullable: false),
                    NumberOfTournamentsPlayed = table.Column<int>(type: "int", nullable: false),
                    BiggestPrizeWon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "CreationDate", "MembersCount", "MoneyWon", "Name", "Owner", "Place" },
                values: new object[] { 1, new DateTime(2022, 4, 11, 21, 14, 40, 882, DateTimeKind.Local).AddTicks(878), 5, 5000, "Liquid", "Pepek", "Praha" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "CreationDate", "MembersCount", "MoneyWon", "Name", "Owner", "Place" },
                values: new object[] { 2, new DateTime(2022, 4, 11, 21, 14, 40, 882, DateTimeKind.Local).AddTicks(936), 8, 100, "MeXXeSSovi Kamarádi", "NeeX", "Brno" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "BiggestPrizeWon", "FirstName", "LastName", "MoneyWon", "NickName", "NumberOfTournamentsPlayed", "StartedPlaying", "TeamId" },
                values: new object[] { 1, 300, "Jouda", "Špatný", 500, "Aldra1n", 3, 2013, 1 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "BiggestPrizeWon", "FirstName", "LastName", "MoneyWon", "NickName", "NumberOfTournamentsPlayed", "StartedPlaying", "TeamId" },
                values: new object[] { 2, 8000, "Jarmil", "Holohlavý", 10000, "Filadelfie", 15, 2015, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
