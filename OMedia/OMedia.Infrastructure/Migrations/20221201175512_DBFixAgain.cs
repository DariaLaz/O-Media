using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMedia.Infrastructure.Migrations
{
    public partial class DBFixAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Competitors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "7c2b72a8-6519-4307-a931-223d769af588", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEOa5fFBl8ugcWn1j+sJj1IPbezvffnDP9iaDukaq4dnVZwFiIKqSKE0g6YtwqTXFfA==", null, false, "2cbbb21b-eefc-4151-b6bb-e76049cac260", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "9046c48e-9216-4090-ae84-ed557ee519db", "agent@mail.com", false, false, null, "agent@mail.com", "agent@mail.com", "AQAAAAEAACcQAAAAEEpEnZ3id68w1DVKFB5qPhDRyp1uGMdlpK7Bu3s2ALNpzp+tNl9ncNZeBvK1ikpwxw==", null, false, "c4863b95-1245-415c-a02a-46d6dd0ce38a", false, "agent@mail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Competitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 1, 19, 55, 11, 696, DateTimeKind.Local).AddTicks(6932));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 1, 19, 55, 11, 697, DateTimeKind.Local).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.CreateIndex(
                name: "IX_Competitors_UserId",
                table: "Competitors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitors_AspNetUsers_UserId",
                table: "Competitors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitors_AspNetUsers_UserId",
                table: "Competitors");

            migrationBuilder.DropIndex(
                name: "IX_Competitors_UserId",
                table: "Competitors");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Competitors");

            migrationBuilder.UpdateData(
                table: "Competitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 1, 18, 48, 7, 888, DateTimeKind.Local).AddTicks(9193));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 1, 18, 48, 7, 889, DateTimeKind.Local).AddTicks(2096));
        }
    }
}
