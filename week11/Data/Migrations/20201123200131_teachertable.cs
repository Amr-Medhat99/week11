using Microsoft.EntityFrameworkCore.Migrations;

namespace week11.Data.Migrations
{
    public partial class teachertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    teacherID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacherAge = table.Column<int>(nullable: false),
                    teacherFirstName = table.Column<string>(nullable: false),
                    teacherLastName = table.Column<string>(nullable: false),
                    teacherGender = table.Column<string>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.teacherID);
                    table.ForeignKey(
                        name: "FK_teachers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_teachers_AppUserId",
                table: "teachers",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "teachers");
        }
    }
}
