using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseSignupSystemServer.Migrations
{
    public partial class FixErrorFKandRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DangKies_HocVien_MaHV",
                table: "DangKies");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKies_LopHoc_MaLop",
                table: "DangKies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DangKies",
                table: "DangKies");

            migrationBuilder.RenameTable(
                name: "DangKies",
                newName: "DangKy");

            migrationBuilder.RenameIndex(
                name: "IX_DangKies_MaHV",
                table: "DangKy",
                newName: "IX_DangKy_MaHV");

            migrationBuilder.AlterColumn<string>(
                name: "MaHV",
                table: "LienHe",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DangKy",
                table: "DangKy",
                columns: new[] { "MaLop", "MaHV" });

            migrationBuilder.CreateIndex(
                name: "IX_LienHe_MaHV",
                table: "LienHe",
                column: "MaHV");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKy_HocVien_MaHV",
                table: "DangKy",
                column: "MaHV",
                principalTable: "HocVien",
                principalColumn: "MaHV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DangKy_LopHoc_MaLop",
                table: "DangKy",
                column: "MaLop",
                principalTable: "LopHoc",
                principalColumn: "MaLop",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LienHe_HocVien_MaHV",
                table: "LienHe",
                column: "MaHV",
                principalTable: "HocVien",
                principalColumn: "MaHV",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DangKy_HocVien_MaHV",
                table: "DangKy");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKy_LopHoc_MaLop",
                table: "DangKy");

            migrationBuilder.DropForeignKey(
                name: "FK_LienHe_HocVien_MaHV",
                table: "LienHe");

            migrationBuilder.DropIndex(
                name: "IX_LienHe_MaHV",
                table: "LienHe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DangKy",
                table: "DangKy");

            migrationBuilder.RenameTable(
                name: "DangKy",
                newName: "DangKies");

            migrationBuilder.RenameIndex(
                name: "IX_DangKy_MaHV",
                table: "DangKies",
                newName: "IX_DangKies_MaHV");

            migrationBuilder.AlterColumn<string>(
                name: "MaHV",
                table: "LienHe",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DangKies",
                table: "DangKies",
                columns: new[] { "MaLop", "MaHV" });

            migrationBuilder.AddForeignKey(
                name: "FK_DangKies_HocVien_MaHV",
                table: "DangKies",
                column: "MaHV",
                principalTable: "HocVien",
                principalColumn: "MaHV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DangKies_LopHoc_MaLop",
                table: "DangKies",
                column: "MaLop",
                principalTable: "LopHoc",
                principalColumn: "MaLop",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
