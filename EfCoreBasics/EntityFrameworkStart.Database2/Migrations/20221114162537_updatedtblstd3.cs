using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkStart.Database.Migrations
{
    public partial class updatedtblstd3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbStudent",
                table: "tbStudent");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "tbStudent",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AddColumn<int>(
                name: "SID",
                table: "tbStudent",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbStudent",
                table: "tbStudent",
                column: "SID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbStudent",
                table: "tbStudent");

            migrationBuilder.DropColumn(
                name: "SID",
                table: "tbStudent");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "tbStudent",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbStudent",
                table: "tbStudent",
                column: "FirstName");
        }
    }
}
