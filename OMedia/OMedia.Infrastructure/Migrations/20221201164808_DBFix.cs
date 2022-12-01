using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMedia.Infrastructure.Migrations
{
    public partial class DBFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Competitors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Competitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 1, 18, 48, 7, 888, DateTimeKind.Local).AddTicks(9193));

            migrationBuilder.UpdateData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "CoolName");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 1, 18, 48, 7, 889, DateTimeKind.Local).AddTicks(2096));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Competitors");

            migrationBuilder.UpdateData(
                table: "Competitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 1, 18, 27, 32, 648, DateTimeKind.Local).AddTicks(6120));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 1, 18, 27, 32, 649, DateTimeKind.Local).AddTicks(1691));
        }
    }
}
