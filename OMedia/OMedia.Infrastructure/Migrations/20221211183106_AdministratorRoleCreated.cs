using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMedia.Infrastructure.Migrations
{
    public partial class AdministratorRoleCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1ed5c75f-525a-42b8-88d5-0a4160f29389", "e2370f30-27e6-4db1-8654-0bee7285dd6c", "Administrator", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cffa3d4a-6a37-49c7-b299-f7e50bdc1ea2", "AQAAAAEAACcQAAAAEPhpK6HqVyLIai5a+dmqogzm8wwnrllwHo9ctP6x+1+0ZrnS+UZzIdEBjdyaLubutw==", "74975ea7-e9aa-4bc6-984c-ddd1e7890afe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b739ba3-1a0d-4f05-97c9-c5bea2731a2b", "AQAAAAEAACcQAAAAEDsWM0YxYggHTq9xFxKA/cwWYGDy0VDEXWHKp1YNWe17oXaWLVIykjJzPnqvpUOXkw==", "cbc2d917-9957-4eaf-b9d0-46d20e69a912" });

            migrationBuilder.UpdateData(
                table: "Competitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 11, 20, 31, 4, 949, DateTimeKind.Local).AddTicks(2872));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 11, 20, 31, 4, 834, DateTimeKind.Local).AddTicks(8708));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ed5c75f-525a-42b8-88d5-0a4160f29389");

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
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 11, 19, 12, 49, 116, DateTimeKind.Local).AddTicks(9656));
        }
    }
}
