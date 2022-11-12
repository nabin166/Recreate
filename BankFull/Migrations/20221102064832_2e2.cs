using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankFull.Migrations
{
    public partial class _2e2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$CWU.ybbRGYvwm6ZHzSFOCeiIcFvD991HkBsfhxOPVJl5Ivv0BXkMG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$k.9yG82/yjx8Qq.mlmMrb.tMpjRedyJbrkhad6tQbddHOIs0B//oq");
        }
    }
}
