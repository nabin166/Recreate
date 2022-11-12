using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankFull.Migrations
{
    public partial class akd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Message_Message",
                table: "User_Message");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$pSLMkBbI8MDzglYS40WxZO4KtIr80dhxEuo6/Bo2CQ7Ao12llaEom");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Message_Message",
                table: "User_Message",
                column: "Message_Id",
                principalTable: "tblMessage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Message_Message",
                table: "User_Message");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$CWU.ybbRGYvwm6ZHzSFOCeiIcFvD991HkBsfhxOPVJl5Ivv0BXkMG");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Message_Message",
                table: "User_Message",
                column: "Message_Id",
                principalTable: "tblMessage",
                principalColumn: "Id");
        }
    }
}
