using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMedia.Infrastructure.Migrations
{
    public partial class SeedAgeGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AgeGroups",
                columns: new[] { "Id", "Age", "CompetitionId", "Gender" },
                values: new object[,]
                {
                    { 1, 10, null, "Male" },
                    { 2, 12, null, "Male" },
                    { 3, 14, null, "Male" },
                    { 4, 16, null, "Male" },
                    { 5, 18, null, "Male" },
                    { 6, 35, null, "Male" },
                    { 7, 45, null, "Male" },
                    { 8, 55, null, "Male" },
                    { 9, 60, null, "Male" },
                    { 10, 65, null, "Male" },
                    { 11, 70, null, "Male" },
                    { 12, 10, null, "Female" },
                    { 13, 12, null, "Female" },
                    { 14, 14, null, "Female" },
                    { 15, 16, null, "Female" },
                    { 16, 18, null, "Female" },
                    { 17, 21, null, "Female" },
                    { 18, 35, null, "Female" },
                    { 19, 45, null, "Female" },
                    { 20, 55, null, "Female" },
                    { 21, 60, null, "Female" },
                    { 22, 65, null, "Female" },
                    { 23, 70, null, "Female" },
                    { 24, 21, null, "Male" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4275be56-ef7f-4c3a-adc5-278f38293997", "AQAAAAEAACcQAAAAEMApbLNbL+O4F4KKfPB8EiAdYA7ndLUed2CzgvT54ZRy6QJW8p2s75lcGP1pubisHQ==", "5128ccd0-eec7-4b08-adfd-faa15b0a5533" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29d1ed2d-139c-43b4-abfa-a65e61021f64", "AQAAAAEAACcQAAAAEI4eBtDiJdN8wq5739EOlBQ6RQsNbYDOh7ao9Xt669aylIkZ3bDDIT2anb2bW4Siog==", "256978cb-dbd6-4054-8dbc-327c7fd8ae7a" });

            migrationBuilder.UpdateData(
                table: "Competitions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 2, 19, 34, 12, 903, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 2, 19, 34, 12, 904, DateTimeKind.Local).AddTicks(4205));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AgeGroups",
                keyColumn: "Id",
                keyValue: 24);

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
    }
}
