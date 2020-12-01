using Microsoft.EntityFrameworkCore.Migrations;

namespace week11.Data.Migrations
{
    public partial class addxint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_xx",
                table: "xx");

            migrationBuilder.DropColumn(
                name: "id",
                table: "xx");

            migrationBuilder.AddColumn<int>(
                name: "xid",
                table: "xx",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_xx",
                table: "xx",
                column: "xid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_xx",
                table: "xx");

            migrationBuilder.DropColumn(
                name: "xid",
                table: "xx");

            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "xx",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_xx",
                table: "xx",
                column: "id");
        }
    }
}
