using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkStart.Database.Migrations
{
    public partial class updatedtblstd1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbStudent",
                table: "tbStudent");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tbStudent");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "tbStudent",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbStudent",
                table: "tbStudent",
                column: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbStudent",
                table: "tbStudent");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "tbStudent",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "tbStudent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbStudent",
                table: "tbStudent",
                column: "Id");
        }
    }
}
