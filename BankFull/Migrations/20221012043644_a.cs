using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankFull.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$x.7vOG.Nrs9C/hbbLrGkI.u6sdToRWKUgNwYza00UXts3NsKZZJri");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$4ORn4.DK82ZAuHRrjo72ZuKVjxgSeQKqMneIFDy9j8T6scwPDj1g.");
        }
    }
}
