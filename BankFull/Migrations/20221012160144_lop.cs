using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankFull.Migrations
{
    public partial class lop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$BkLGuGdajgSsNe6RWI04keK4S8VPa803y5CS9XT.O2pOGgES/9YXy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$4tGY7sAxShmmUxuWk9T5l.SodmZEvQPUkQ5ozpv97VXsrP0Mobhy6");
        }
    }
}
