using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankFull.Migrations
{
    public partial class j33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$k.9yG82/yjx8Qq.mlmMrb.tMpjRedyJbrkhad6tQbddHOIs0B//oq");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$vqmxAQSnKX4GR2VE4/ZCkOj1jAFr2tbvcJvWCKirzXRytfXt548b6");
        }
    }
}
