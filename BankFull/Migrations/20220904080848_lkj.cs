using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankFull.Migrations
{
    public partial class lkj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Message_User",
                table: "User_Message");

            migrationBuilder.DropIndex(
                name: "IX_User_Message_User_Id",
                table: "User_Message");

            migrationBuilder.AddColumn<int>(
                name: "RecUserId",
                table: "User_Message",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Receiver_Name",
                table: "Assign",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_User_Message_RecUserId",
                table: "User_Message",
                column: "RecUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecUser__User",
                table: "User_Message",
                column: "RecUserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecUser__User",
                table: "User_Message");

            migrationBuilder.DropIndex(
                name: "IX_User_Message_RecUserId",
                table: "User_Message");

            migrationBuilder.DropColumn(
                name: "RecUserId",
                table: "User_Message");

            migrationBuilder.AlterColumn<string>(
                name: "Receiver_Name",
                table: "Assign",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_User_Message_User_Id",
                table: "User_Message",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Message_User",
                table: "User_Message",
                column: "User_Id",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
