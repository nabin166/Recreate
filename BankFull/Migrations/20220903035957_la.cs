using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankFull.Migrations
{
    public partial class la : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblMessage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bank = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    DocumentPath = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Messages = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
                    status = table.Column<bool>(type: "bit", unicode: false, maxLength: 50, nullable: true),
                    role_Id = table.Column<int>(type: "int", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role",
                        column: x => x.role_Id,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Assign",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Receiver_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Received_Amount = table.Column<int>(type: "int", nullable: false),
                    Messageid = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Bank Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AccountNumber = table.Column<string>(type: "nchar(250)", fixedLength: true, maxLength: 250, nullable: true),
                    AccountName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Address = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    AmountIN = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    AmountOut = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    TransactionLimit = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    User_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bank Details_User",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    DrAmount = table.Column<int>(name: "Dr Amount", type: "int", nullable: true),
                    CrAmount = table.Column<int>(name: "Cr Amount", type: "int", nullable: true),
                    User_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_User",
                        column: x => x.User_id,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User_Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: true),
                    Message_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Message_Message",
                        column: x => x.Message_Id,
                        principalTable: "tblMessage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Message_User",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assign_Messageid",
                table: "Assign",
                column: "Messageid");

            migrationBuilder.CreateIndex(
                name: "IX_Bank Details_User_Id",
                table: "Bank Details",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_User_id",
                table: "Transaction",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_role_Id",
                table: "User",
                column: "role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Message_Message_Id",
                table: "User_Message",
                column: "Message_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Message_User_Id",
                table: "User_Message",
                column: "User_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assign");

            migrationBuilder.DropTable(
                name: "Bank Details");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "User_Message");

            migrationBuilder.DropTable(
                name: "tblMessage");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
