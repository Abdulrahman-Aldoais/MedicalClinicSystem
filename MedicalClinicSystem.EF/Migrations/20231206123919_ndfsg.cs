using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalClinicSystem.EF.Migrations
{
    public partial class ndfsg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 12, 6, 15, 39, 18, 805, DateTimeKind.Local).AddTicks(8280));

            migrationBuilder.UpdateData(
                schema: "myschema",
                table: "User",
                keyColumn: "Id",
                keyValue: "56508bd7-661c-4f12-907e-e814b101da5d",
                columns: new[] { "ConcurrencyStamp", "Pass", "PasswordHash", "Salt", "SecurityStamp" },
                values: new object[] { "f0c0850c-f974-4c21-bd94-998bd3e2cc01", "814096F5CDC7C8E41AA3A82B268BD3F9E7D42845411CFF9E6371CA159C7A8097", "814096F5CDC7C8E41AA3A82B268BD3F9E7D42845411CFF9E6371CA159C7A8097", "12/6/2023 3:39:18 PM", "0697727a-786d-4dad-8d1d-cf811dccd0bd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 12, 3, 22, 31, 5, 712, DateTimeKind.Local).AddTicks(4219));

            migrationBuilder.UpdateData(
                schema: "myschema",
                table: "User",
                keyColumn: "Id",
                keyValue: "56508bd7-661c-4f12-907e-e814b101da5d",
                columns: new[] { "ConcurrencyStamp", "Pass", "PasswordHash", "Salt", "SecurityStamp" },
                values: new object[] { "23434f7f-3bc1-4025-a0c1-1380386f02f0", "3D8DB33C393A0A6B7FD67A822C6F9961768EAA94EB0185AA20825FD700EBC007", "3D8DB33C393A0A6B7FD67A822C6F9961768EAA94EB0185AA20825FD700EBC007", "12/3/2023 10:31:05 PM", "c7a54c5e-b100-409d-873a-900f9696115b" });
        }
    }
}
