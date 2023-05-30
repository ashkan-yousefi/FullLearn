using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullLearn.Data.Migrations
{
    public partial class UpdateMigrationNotMapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseGroups_SubGroup",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "SubGroup",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseGroups_SubGroup",
                table: "Courses",
                column: "SubGroup",
                principalTable: "CourseGroups",
                principalColumn: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseGroups_SubGroup",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "SubGroup",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseGroups_SubGroup",
                table: "Courses",
                column: "SubGroup",
                principalTable: "CourseGroups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
