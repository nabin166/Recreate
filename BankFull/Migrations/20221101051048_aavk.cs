using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankFull.Migrations
{
    public partial class aavk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionLimit",
                table: "Bank Details");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$lu7bmAA8fd52WngJ4XNcv.IAjzKwS5KUmJMYE4m.z386HKAM8vrqK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransactionLimit",
                table: "Bank Details",
                type: "nchar(100)",
                fixedLength: true,
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$hjQ3XWyST6TSTdCK4jylReDQcHCayNqIVMsWFPI1cY4Q.vJMdIDBG");
        }
    }
}
