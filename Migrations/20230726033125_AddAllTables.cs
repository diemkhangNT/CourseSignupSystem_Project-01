using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseSignupSystemServer.Migrations
{
    public partial class AddAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HinhDaiDien",
                table: "NhanVien",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "Luong",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "ChucVu",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "BoMon",
                columns: table => new
                {
                    MaBM = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenBM = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoMon", x => x.MaBM);
                });

            migrationBuilder.CreateTable(
                name: "DoanhThu",
                columns: table => new
                {
                    MaDoanhThu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ThoiGian = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TongTien = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoanhThu", x => x.MaDoanhThu);
                });

            migrationBuilder.CreateTable(
                name: "HocVien",
                columns: table => new
                {
                    MaHV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenHV = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhuHuynh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SDTLienLac = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocVien", x => x.MaHV);
                });

            migrationBuilder.CreateTable(
                name: "LichNghi",
                columns: table => new
                {
                    MaLN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayBD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichNghi", x => x.MaLN);
                });

            migrationBuilder.CreateTable(
                name: "LienHe",
                columns: table => new
                {
                    MaLH = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NgayLH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaHV = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LienHe", x => x.MaLH);
                });

            migrationBuilder.CreateTable(
                name: "LoaiDiem",
                columns: table => new
                {
                    MaLDiem = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLDiem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeSo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiDiem", x => x.MaLDiem);
                });

            migrationBuilder.CreateTable(
                name: "NienKhoa",
                columns: table => new
                {
                    MaNK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenNK = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ThoiGian = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NienKhoa", x => x.MaNK);
                });

            migrationBuilder.CreateTable(
                name: "GiangVien",
                columns: table => new
                {
                    MaGV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenGV = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CMND = table.Column<int>(type: "int", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    HinhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayHopTac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThaiHD = table.Column<bool>(type: "bit", nullable: false),
                    MaBM = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaLuong = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiangVien", x => x.MaGV);
                    table.ForeignKey(
                        name: "FK_GiangVien_BoMon_MaBM",
                        column: x => x.MaBM,
                        principalTable: "BoMon",
                        principalColumn: "MaBM",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiangVien_Luong_MaLuong",
                        column: x => x.MaLuong,
                        principalTable: "Luong",
                        principalColumn: "MaLuong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    MaMH = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenMH = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    MaBM = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHoc", x => x.MaMH);
                    table.ForeignKey(
                        name: "FK_MonHoc_BoMon_MaBM",
                        column: x => x.MaBM,
                        principalTable: "BoMon",
                        principalColumn: "MaBM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    MaKhoa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenKhoa = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    MaNienKhoa = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa", x => x.MaKhoa);
                    table.ForeignKey(
                        name: "FK_Khoa_NienKhoa_MaNienKhoa",
                        column: x => x.MaNienKhoa,
                        principalTable: "NienKhoa",
                        principalColumn: "MaNK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diem",
                columns: table => new
                {
                    MaHV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaMH = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaLDiem = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoDiem = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diem", x => new { x.MaMH, x.MaHV, x.MaLDiem });
                    table.ForeignKey(
                        name: "FK_Diem_HocVien_MaHV",
                        column: x => x.MaHV,
                        principalTable: "HocVien",
                        principalColumn: "MaHV",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diem_LoaiDiem_MaLDiem",
                        column: x => x.MaLDiem,
                        principalTable: "LoaiDiem",
                        principalColumn: "MaLDiem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diem_MonHoc_MaMH",
                        column: x => x.MaMH,
                        principalTable: "MonHoc",
                        principalColumn: "MaMH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    MaLop = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    HocPhi = table.Column<double>(type: "float", nullable: false),
                    NgayKhaiGiang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoBuoiHoc = table.Column<int>(type: "int", nullable: false),
                    MaKhoa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaMH = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaDT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaLichNghi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaGV = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.MaLop);
                    table.ForeignKey(
                        name: "FK_LopHoc_DoanhThu_MaDT",
                        column: x => x.MaDT,
                        principalTable: "DoanhThu",
                        principalColumn: "MaDoanhThu",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHoc_GiangVien_MaGV",
                        column: x => x.MaGV,
                        principalTable: "GiangVien",
                        principalColumn: "MaGV",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHoc_Khoa_MaKhoa",
                        column: x => x.MaKhoa,
                        principalTable: "Khoa",
                        principalColumn: "MaKhoa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHoc_LichNghi_MaLichNghi",
                        column: x => x.MaLichNghi,
                        principalTable: "LichNghi",
                        principalColumn: "MaLN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LopHoc_MonHoc_MaMH",
                        column: x => x.MaMH,
                        principalTable: "MonHoc",
                        principalColumn: "MaMH",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DangKies",
                columns: table => new
                {
                    MaHV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaLop = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayDK = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThuHocPhi = table.Column<bool>(type: "bit", nullable: false),
                    NgayThuHP = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKies", x => new { x.MaLop, x.MaHV });
                    table.ForeignKey(
                        name: "FK_DangKies_HocVien_MaHV",
                        column: x => x.MaHV,
                        principalTable: "HocVien",
                        principalColumn: "MaHV",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DangKies_LopHoc_MaLop",
                        column: x => x.MaLop,
                        principalTable: "LopHoc",
                        principalColumn: "MaLop",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LichVang",
                columns: table => new
                {
                    MaHV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaLop = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayVang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LyDo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichVang", x => new { x.MaLop, x.MaHV });
                    table.ForeignKey(
                        name: "FK_LichVang_HocVien_MaHV",
                        column: x => x.MaHV,
                        principalTable: "HocVien",
                        principalColumn: "MaHV",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichVang_LopHoc_MaLop",
                        column: x => x.MaLop,
                        principalTable: "LopHoc",
                        principalColumn: "MaLop",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DangKies_MaHV",
                table: "DangKies",
                column: "MaHV");

            migrationBuilder.CreateIndex(
                name: "IX_Diem_MaHV",
                table: "Diem",
                column: "MaHV");

            migrationBuilder.CreateIndex(
                name: "IX_Diem_MaLDiem",
                table: "Diem",
                column: "MaLDiem");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_MaBM",
                table: "GiangVien",
                column: "MaBM");

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_MaLuong",
                table: "GiangVien",
                column: "MaLuong");

            migrationBuilder.CreateIndex(
                name: "IX_Khoa_MaNienKhoa",
                table: "Khoa",
                column: "MaNienKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_LichVang_MaHV",
                table: "LichVang",
                column: "MaHV");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_MaDT",
                table: "LopHoc",
                column: "MaDT");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_MaGV",
                table: "LopHoc",
                column: "MaGV");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_MaKhoa",
                table: "LopHoc",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_MaLichNghi",
                table: "LopHoc",
                column: "MaLichNghi");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_MaMH",
                table: "LopHoc",
                column: "MaMH");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_MaBM",
                table: "MonHoc",
                column: "MaBM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DangKies");

            migrationBuilder.DropTable(
                name: "Diem");

            migrationBuilder.DropTable(
                name: "LichVang");

            migrationBuilder.DropTable(
                name: "LienHe");

            migrationBuilder.DropTable(
                name: "LoaiDiem");

            migrationBuilder.DropTable(
                name: "HocVien");

            migrationBuilder.DropTable(
                name: "LopHoc");

            migrationBuilder.DropTable(
                name: "DoanhThu");

            migrationBuilder.DropTable(
                name: "GiangVien");

            migrationBuilder.DropTable(
                name: "Khoa");

            migrationBuilder.DropTable(
                name: "LichNghi");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "NienKhoa");

            migrationBuilder.DropTable(
                name: "BoMon");

            migrationBuilder.AlterColumn<string>(
                name: "HinhDaiDien",
                table: "NhanVien",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "Luong",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "ChucVu",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
