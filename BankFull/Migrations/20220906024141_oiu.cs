using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankFull.Migrations
{
    public partial class oiu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_User",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "User_id",
                table: "Transaction",
                newName: "Message_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_User_id",
                table: "Transaction",
                newName: "IX_Transaction_Message_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_User",
                table: "Transaction",
                column: "Message_Id",
                principalTable: "tblMessage",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_User",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "Message_Id",
                table: "Transaction",
                newName: "User_id");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_Message_Id",
                table: "Transaction",
                newName: "IX_Transaction_User_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_User",
                table: "Transaction",
                column: "User_id",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
