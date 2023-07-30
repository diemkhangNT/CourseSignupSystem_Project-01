using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseSignupSystemServer.Migrations
{
    public partial class UpdateNienKhoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenNK",
                table: "NienKhoa");

            migrationBuilder.AlterColumn<double>(
                name: "HeSo",
                table: "LoaiDiem",
                type: "float",
                nullable: false,
                defaultValue: 1.0,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenNK",
                table: "NienKhoa",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<double>(
                name: "HeSo",
                table: "LoaiDiem",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 1.0);
        }
    }
}
