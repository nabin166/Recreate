using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankFull.Migrations
{
    public partial class ram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotoSends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoSends", x => x.Id);
                });

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
                name: "TransactionRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Phone = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
                    status = table.Column<bool>(type: "bit", unicode: false, maxLength: 50, nullable: true),
                    role_Id = table.Column<int>(type: "int", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "Bank Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    AccountNumber = table.Column<string>(type: "nchar(250)", fixedLength: true, maxLength: 250, nullable: false),
                    AccountName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Address = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    TransactionLimit = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
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
                name: "payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payment = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datetime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bank Details_User1111",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblMessage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    DocumentPath = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Messages = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bank Details_User1",
                        column: x => x.BankId,
                        principalTable: "Bank Details",
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
                    Message_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_User",
                        column: x => x.Message_Id,
                        principalTable: "tblMessage",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User_Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Role" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Role" },
                values: new object[] { 2, "User" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Role" },
                values: new object[] { 3, "Agent" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "Phone", "role_Id", "status" },
                values: new object[] { 1, "Bharatpur", "niraj@gmail.com", "Niraj Baral", "$2a$11$hu7egFL.2eMi/p.X0Fc9o.ftamyrHj8HIaa2nZkWkalqY.UNTUJFq", "9855075102", 1, true });

            migrationBuilder.CreateIndex(
                name: "IX_Bank Details_User_Id",
                table: "Bank Details",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_UserId",
                table: "payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMessage_BankId",
                table: "tblMessage",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_Message_Id",
                table: "Transaction",
                column: "Message_Id");

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
                name: "payments");

            migrationBuilder.DropTable(
                name: "PhotoSends");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "TransactionRates");

            migrationBuilder.DropTable(
                name: "User_Message");

            migrationBuilder.DropTable(
                name: "tblMessage");

            migrationBuilder.DropTable(
                name: "Bank Details");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
