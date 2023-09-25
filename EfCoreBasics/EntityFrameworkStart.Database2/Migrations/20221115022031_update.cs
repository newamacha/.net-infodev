using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkStart.Database.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SID",
                table: "tbStudent",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "tbStudent",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tbStudent",
                newName: "SID");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "tbStudent",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldNullable: true);
        }
    }
}
