using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMedia.Infrastructure.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistanceTypes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ed5c75f-525a-42b8-88d5-0a4160f29389");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Competitors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AgeGroups",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e43db659-0be6-41be-95e1-1bfa6d676b2d", "d7f2cb5b-0a87-46c2-ba7c-b10e09ae089e", "Administrator", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "303d79b9-454c-4a61-b4a9-28e1bb4bc982", "AQAAAAEAACcQAAAAEDP8R6mf+8s8xsCb/G+gxJ0GxXlIC6qLWI97wO4UYD6quAx3WxJlSEfJPxgU60GOXg==", "ccf749e6-788f-4332-ba02-c7849b072a96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df81b52d-5fa9-4f78-bc96-edbc9ef055b2", "AQAAAAEAACcQAAAAEJwc3jkmFoc0SXnty0xYQl7byRpbHsR/TFALkUq5YS8+2y/1XpItNSzSbcMv/b58aQ==", "3aba9df9-cb95-487f-afb6-07e35fab45db" });

            migrationBuilder.UpdateData(
                table: "Competitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 12, 16, 20, 17, 289, DateTimeKind.Local).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 12, 16, 20, 17, 266, DateTimeKind.Local).AddTicks(3341));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e43db659-0be6-41be-95e1-1bfa6d676b2d");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Competitors");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AgeGroups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DistanceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistanceTypes", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "DistanceTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 1, "Sprint" },
                    { 2, "Middle" },
                    { 3, "Long" },
                    { 4, "Relay" },
                    { 5, "Sky" },
                    { 6, "O-Bike" }
                });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 11, 20, 31, 4, 834, DateTimeKind.Local).AddTicks(8708));
        }
    }
}
