using Microsoft.EntityFrameworkCore.Migrations;

namespace week11.Data.Migrations
{
    public partial class addManagerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "managers",
                columns: table => new
                {
                    managerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    managerFname = table.Column<string>(nullable: false),
                    managerLname = table.Column<string>(nullable: false),
                    managerGender = table.Column<string>(nullable: false),
                    AppUserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_managers", x => x.managerID);
                    table.ForeignKey(
                        name: "FK_managers_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_managers_AppUserID",
                table: "managers",
                column: "AppUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "managers");
        }
    }
}
