using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankFull.Migrations
{
    public partial class bi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bank Details_User",
                table: "Bank Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Bank Details_User1",
                table: "tblMessage");

            migrationBuilder.AlterColumn<int>(
                name: "BankId",
                table: "tblMessage",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "User_Id",
                table: "Bank Details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                values: new object[] { 1, "Bharatpur", "niraj@gmail.com", "Niraj Baral", "$2a$11$1kQahuownAnKSQ0mteMNGuT4Wy1rfhJOR.d4.atb161IVfoVruPqW", "9855075102", 1, true });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "Phone", "role_Id", "status" },
                values: new object[] { 2, "Bharatpur", "nabin@gmail.com", "Nabin Aryal", "$2a$11$vgn4bjCVrkbySvt9zT3Uue1StG/zP5TAr1r2K/mXlrsfM9YuNylZG", "9855075102", 2, true });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "Phone", "role_Id", "status" },
                values: new object[] { 3, "Bharatpur", "sandip@gmail.com", "Sandip Adhikari", "$2a$11$TflEZlG77q0lCSDLo7ZNluXI3MLJlS1FQpb/kLB19VGVCbcRYieam", "9855075102", 1, true });

            migrationBuilder.AddForeignKey(
                name: "FK_Bank Details_User",
                table: "Bank Details",
                column: "User_Id",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bank Details_User1",
                table: "tblMessage",
                column: "BankId",
                principalTable: "Bank Details",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bank Details_User",
                table: "Bank Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Bank Details_User1",
                table: "tblMessage");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "BankId",
                table: "tblMessage",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "User_Id",
                table: "Bank Details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bank Details_User",
                table: "Bank Details",
                column: "User_Id",
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
        }
    }
}
