using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankFull.Migrations
{
    public partial class av893 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$hjQ3XWyST6TSTdCK4jylReDQcHCayNqIVMsWFPI1cY4Q.vJMdIDBG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$IAzxfYFXnf8zqV73Gqio3.QcOgSX7S385xNVsIndENu0IaRhgJ/gS");
        }
    }
}
