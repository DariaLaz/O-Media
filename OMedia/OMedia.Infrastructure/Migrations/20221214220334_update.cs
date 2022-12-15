using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMedia.Infrastructure.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e43db659-0be6-41be-95e1-1bfa6d676b2d");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Competitors");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e10fe54b-3bf8-4546-8cf8-e075f8df11de", "27447e53-7428-42b7-bfa4-cd0a8eace5ad", "Administrator", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a02ca162-32d8-4f17-a5f1-26297d12b99d", "AQAAAAEAACcQAAAAEP+RZ+xCQY/W1uoh8RNIGhhGIVFQRPIb1MNy7X7kd4ymtJ4+8QgdTgwpQlLfHHQ4hQ==", "c211823d-484c-4407-abeb-1c3ad81bd156" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7965071c-fe44-4187-b059-869293af57e4", "AQAAAAEAACcQAAAAEJ3Kj2waujl0r1P6VhE9XszgKV5WBXGyEzYJ+2JBhJEq4keria97f4Df9QIyksmrjg==", "23cba7e3-e8fa-4ada-8b16-5bb1084a14f0" });

            migrationBuilder.UpdateData(
                table: "Competitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 15, 0, 3, 33, 516, DateTimeKind.Local).AddTicks(1386));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 15, 0, 3, 33, 498, DateTimeKind.Local).AddTicks(3036));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e10fe54b-3bf8-4546-8cf8-e075f8df11de");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Competitors",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
