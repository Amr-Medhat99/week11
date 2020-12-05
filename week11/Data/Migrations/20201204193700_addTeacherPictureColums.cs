using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace week11.Data.Migrations
{
    public partial class addTeacherPictureColums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "teacherPic",
                table: "teachers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "teacherPic",
                table: "teachers");
        }
    }
}
