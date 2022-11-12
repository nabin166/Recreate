using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankFull.Migrations
{
    public partial class avjer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bank Details_User",
                table: "Bank Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Bank Details_User1111",
                table: "payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Bank Details_User1",
                table: "tblMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_User",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$vqmxAQSnKX4GR2VE4/ZCkOj1jAFr2tbvcJvWCKirzXRytfXt548b6");

            migrationBuilder.AddForeignKey(
                name: "FK_Bank Details_User",
                table: "Bank Details",
                column: "User_Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bank Details_User1111",
                table: "payments",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bank Details_User1",
                table: "tblMessage",
                column: "BankId",
                principalTable: "Bank Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_User",
                table: "Transaction",
                column: "Message_Id",
                principalTable: "tblMessage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role",
                table: "User",
                column: "role_Id",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bank Details_User",
                table: "Bank Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Bank Details_User1111",
                table: "payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Bank Details_User1",
                table: "tblMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_User",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$lu7bmAA8fd52WngJ4XNcv.IAjzKwS5KUmJMYE4m.z386HKAM8vrqK");

            migrationBuilder.AddForeignKey(
                name: "FK_Bank Details_User",
                table: "Bank Details",
                column: "User_Id",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bank Details_User1111",
                table: "payments",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bank Details_User1",
                table: "tblMessage",
                column: "BankId",
                principalTable: "Bank Details",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_User",
                table: "Transaction",
                column: "Message_Id",
                principalTable: "tblMessage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role",
                table: "User",
                column: "role_Id",
                principalTable: "Role",
                principalColumn: "Id");
        }
    }
}
