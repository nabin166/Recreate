using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankFull.Migrations
{
    public partial class a1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$ildMPihlQmQQH5QKX9mbzuxlldgg2sw8kD/G0BdqGBkBGORN0PK4y");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$7H2tbiCoC9rvgADvUewbM.cCeUqAsaynTWtQSS/1OEKSyf3OFut7q");
        }
    }
}
