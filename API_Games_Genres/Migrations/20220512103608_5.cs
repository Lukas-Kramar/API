using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Games_Genres.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 5, 12, 12, 36, 8, 212, DateTimeKind.Local).AddTicks(8251));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 5, 12, 12, 36, 8, 212, DateTimeKind.Local).AddTicks(8380));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 4, 21, 21, 9, 10, 835, DateTimeKind.Local).AddTicks(2976));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 4, 21, 21, 9, 10, 835, DateTimeKind.Local).AddTicks(3040));
        }
    }
}
