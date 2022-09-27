using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankFull.Migrations
{
    public partial class az : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[,]
                {
                    { 1, "Bharatpur", "niraj@gmail.com", "Niraj Baral", "$2a$11$P0xdZqDv.1zNblZLmnzELe71u.bMBrmMI1SBCGmFPaDHLpKsF3Ale", "9855075102", 1, true },
                    { 2, "Bharatpur", "nabin@gmail.com", "Nabin Aryal", "$2a$11$mYBy8srh1K5rJRDO8tY94OmCqMYzfTFS1qQn5eMaNhkjXx0/GLrby", "9855075102", 2, true },
                    { 3, "Bharatpur", "sandip@gmail.com", "Sandip Adhikari", "$2a$11$Vb.DF31hSN9eGyhwsC036eDxEVaYZRBV4rDakfAxHiJVJvX2Lvw8C", "9855075102", 1, true },
                    { 4, "Bharatpur", "parkash@gmail.com", "Prakash Adhikari", "$2a$11$ZePVNImPAij1mJLumliSUOR./1IpwkzxSYAcKSV2hAI6c99YSV3RO", "9855075102", 3, true },
                    { 5, "Bharatpur", "pradip@gmail.com", "pradip Adhikari", "$2a$11$QMb34ASTtCJr8sIMAg25pOwX1fltW3TiS5kcb3O3r1QcrjQRAFwJy", "9855075102", 3, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
