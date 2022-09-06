using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankFull.Migrations
{
    public partial class lk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecUser__User",
                table: "User_Message");

            migrationBuilder.DropTable(
                name: "Assign");

            migrationBuilder.DropIndex(
                name: "IX_User_Message_RecUserId",
                table: "User_Message");

            migrationBuilder.DropColumn(
                name: "RecUserId",
                table: "User_Message");

            migrationBuilder.DropColumn(
                name: "Bank",
                table: "tblMessage");

            migrationBuilder.DropColumn(
                name: "AmountIN",
                table: "Bank Details");

            migrationBuilder.DropColumn(
                name: "AmountOut",
                table: "Bank Details");

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "tblMessage",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Message_User_Id",
                table: "User_Message",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tblMessage_BankId",
                table: "tblMessage",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bank Details_User1",
                table: "tblMessage",
                column: "BankId",
                principalTable: "Bank Details",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Message_User",
                table: "User_Message",
                column: "User_Id",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bank Details_User1",
                table: "tblMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Message_User",
                table: "User_Message");

            migrationBuilder.DropIndex(
                name: "IX_User_Message_User_Id",
                table: "User_Message");

            migrationBuilder.DropIndex(
                name: "IX_tblMessage_BankId",
                table: "tblMessage");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "tblMessage");

            migrationBuilder.AddColumn<int>(
                name: "RecUserId",
                table: "User_Message",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bank",
                table: "tblMessage",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AmountIN",
                table: "Bank Details",
                type: "nchar(100)",
                fixedLength: true,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AmountOut",
                table: "Bank Details",
                type: "nchar(100)",
                fixedLength: true,
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Assign",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Messageid = table.Column<int>(type: "int", nullable: false),
                    Received_Amount = table.Column<int>(type: "int", nullable: false),
                    Receiver_Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assign_Message",
                        column: x => x.Messageid,
                        principalTable: "tblMessage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Message_RecUserId",
                table: "User_Message",
                column: "RecUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assign_Messageid",
                table: "Assign",
                column: "Messageid");

            migrationBuilder.AddForeignKey(
                name: "FK_RecUser__User",
                table: "User_Message",
                column: "RecUserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
