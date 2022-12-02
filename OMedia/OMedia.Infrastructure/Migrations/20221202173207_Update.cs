using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMedia.Infrastructure.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e2be334-a40f-4f83-9534-ec211947174b", "AQAAAAEAACcQAAAAEMJB12Mqda21ccUEzkUruqieyLQ2KsNy7gcojlRFHStNimuL2N/ZiSYmiCNC7Bx0DQ==", "adc40fcf-bdd7-4fe2-95ee-ea2f42a7c35c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ad5c864-34b5-4fc6-829f-77c1cc451fb0", "AQAAAAEAACcQAAAAECTDDLQw2WNfggaJNEtm+r3KFkMqHPvpG+vnCjlyge1u0f0YAFbvVgDfXJDf0nlQmA==", "4d60cd18-78a5-4459-a847-22b9b01f1a34" });

            migrationBuilder.UpdateData(
                table: "Competitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 2, 19, 32, 6, 368, DateTimeKind.Local).AddTicks(8709));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 2, 19, 32, 6, 369, DateTimeKind.Local).AddTicks(3968));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d98f5909-035f-45dc-856d-5edcfa7a0929", "AQAAAAEAACcQAAAAEBhSOmupVIrKQwYCre0FbWTLEC8nmuUiSjw2cHHm9mJ3Tg+HEsfdliCnlrD1yGqDzA==", "21b10681-8fcb-47b8-ad93-a002636b0a4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41a0d833-6e88-4911-a294-2c10ae0c2ab8", "AQAAAAEAACcQAAAAEN0k8qvWqkqUSwAotAvJFug271QJ6HywSudRnIHEitBHue0e7rDFLTJZdSAI6mgunQ==", "c73b46f9-6e6e-4e9a-8f52-bac135b2e24d" });

            migrationBuilder.UpdateData(
                table: "Competitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 2, 17, 39, 45, 46, DateTimeKind.Local).AddTicks(8508));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 2, 17, 39, 45, 47, DateTimeKind.Local).AddTicks(2427));
        }
    }
}
