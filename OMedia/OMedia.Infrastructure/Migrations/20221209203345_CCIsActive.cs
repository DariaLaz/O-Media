using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMedia.Infrastructure.Migrations
{
    public partial class CCIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CompetitionsCompetitors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3ace41b-75dd-46b9-a4cf-ef890f7913db", "AQAAAAEAACcQAAAAEP/lXbI8tGkMQRT941MTKCRBFQJKGKGw0hMXPDTmROG/j6LwXsdRoCJ7xsGYnemu9w==", "6164a7e9-e183-4d33-9efd-bcabf99c50de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7d5245a-41fc-48ed-ac60-362242b11423", "AQAAAAEAACcQAAAAEOLXCewcXsvaTIWJV7rvyrd7frue/DbLX55wfujjNGJbYE5db2hshv/sN3loLUSEtQ==", "00466ee4-9809-4401-9bbc-f5ed0da00cf3" });

            migrationBuilder.UpdateData(
                table: "Competitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 9, 22, 33, 43, 835, DateTimeKind.Local).AddTicks(5078));

            migrationBuilder.UpdateData(
                table: "CompetitionsCompetitors",
                keyColumns: new[] { "CompetitionId", "CompetitorId" },
                keyValues: new object[] { 1, 1 },
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 9, 22, 33, 43, 800, DateTimeKind.Local).AddTicks(67));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CompetitionsCompetitors");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13ad0522-47f9-4c51-a65a-19d559903704", "AQAAAAEAACcQAAAAEHPzStmTHyIpX6S/bDWmlHLomWeNoG1NchtPQOmgnRvhJEI4IANKtkOdZe3QevKzXg==", "14f521b0-5f5a-45b4-887d-1f390f1881de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d8d9d1c-6616-4fe2-b0e3-683da577f468", "AQAAAAEAACcQAAAAEP3O3MsfMHTtAvEtKSVoygYdc2GIxgfufF0IPHZyGogPB0tbeUshRH8RpBiM1FFvVA==", "80c6bb20-10bd-4568-ba46-f28b10502b10" });

            migrationBuilder.UpdateData(
                table: "Competitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 7, 19, 51, 56, 114, DateTimeKind.Local).AddTicks(8155));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 7, 19, 51, 56, 78, DateTimeKind.Local).AddTicks(9871));
        }
    }
}
