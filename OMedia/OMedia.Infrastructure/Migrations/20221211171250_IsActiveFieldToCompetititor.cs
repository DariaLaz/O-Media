using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMedia.Infrastructure.Migrations
{
    public partial class IsActiveFieldToCompetititor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Competitors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "325a5a85-4694-4c34-aeec-73f3ab86a128", "AQAAAAEAACcQAAAAEKPZWh5ueuRUDf7XnyUlQsYV+W3e9t0jP1O4gtJMnH+3Lir3ZiHogg+NSF+wwtF3KQ==", "ce7f9954-c9ca-4795-943b-dac331d9f0aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cefab6d1-bd70-43da-af80-5b6c2b3dbe13", "AQAAAAEAACcQAAAAEBAIqeYVcsObQ/E87PbucXW5XJhkz0yL2QKvvUpN18KodoP844kSVk2dAj8DFzPIdg==", "f8688629-0d39-4035-b491-fed2e73826c7" });

            migrationBuilder.UpdateData(
                table: "Competitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 11, 19, 12, 49, 151, DateTimeKind.Local).AddTicks(8607));

            migrationBuilder.UpdateData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 11, 19, 12, 49, 116, DateTimeKind.Local).AddTicks(9656));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Competitors");

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
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 9, 22, 33, 43, 800, DateTimeKind.Local).AddTicks(67));
        }
    }
}
