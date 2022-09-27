using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankFull.Migrations
{
    public partial class ab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "TransactionLimit",
                table: "Bank Details",
                type: "nchar(100)",
                fixedLength: true,
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nchar(100)",
                oldFixedLength: true,
                oldMaxLength: 100,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TransactionLimit",
                table: "Bank Details",
                type: "nchar(100)",
                fixedLength: true,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(100)",
                oldFixedLength: true,
                oldMaxLength: 100);

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
        }
    }
}
