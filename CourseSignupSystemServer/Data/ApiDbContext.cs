using CourseSignupSystemServer.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CourseSignupSystemServer.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
        //private readonly HttpContext _httpContext;

        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<Luong> Luongs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<BoMon> BoMons { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<LoaiDiem> LoaiDiems { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<LienHe> LienHes { get; set; }
        public virtual DbSet<LichNghi> LichNghis { get; set; }
        public virtual DbSet<NienKhoa> NienKhoas { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<DoanhThu> DoanhThus { get; set; }
        public virtual DbSet<LopHoc> LopHocs { get; set; }
        public virtual DbSet<Diem> Diems { get; set; }
        public virtual DbSet<DangKy> DangKies { get; set; }
        public virtual DbSet<LichVang> LichVangs { get; set; }
        public virtual DbSet<GiangVien> GiangViens { get; set; }


        //Set up primary key
        public override int SaveChanges()
        {
            Random rnd = new Random();
            const string chars = "abcdefghijklmnopqrstuvwsyz0123456789";
            foreach (var entry in ChangeTracker.Entries().Where(e=>e.State == EntityState.Added))
            {
                if (entry.Entity is ChucVu chucVu)
                {
                    string num = new string(Enumerable.Repeat(chars, 9).Select(s => s[rnd.Next(s.Length)]).ToArray());
                    chucVu.MaCV = "CV" + "_" + num;
                    if (chucVu.MoTa == "string")
                        chucVu.MoTa = null;
                }
                else if(entry.Entity is BoMon boMon) 
                {
                    string num1 = new string(Enumerable.Repeat(chars, 9).Select(s => s[rnd.Next(s.Length)]).ToArray());
                    boMon.MaBM = "BM" + "_" + num1;
                }
                else if (entry.Entity is LoaiDiem loaiDiem)
                {
                    string num2 = new string(Enumerable.Repeat(chars, 4).Select(s => s[rnd.Next(s.Length)]).ToArray());
                    loaiDiem.MaLDiem = "D" + "_" + num2;
                }
                else if (entry.Entity is MonHoc monHoc)
                {
                    string num3 = new string(Enumerable.Repeat(chars, 6).Select(s => s[rnd.Next(s.Length)]).ToArray());
                    monHoc.MaMH = "MH" + "_" + num3;
                }
                else if (entry.Entity is LichNghi lichNghi)
                {
                    string num4 = new string(Enumerable.Repeat(chars, 6).Select(s => s[rnd.Next(s.Length)]).ToArray());
                    string num5 = new string(Enumerable.Repeat(chars, 6).Select(s => s[rnd.Next(s.Length)]).ToArray());
                    lichNghi.MaLN = "LN" + "_" + num4 + "_" + num5;
                }
                else if (entry.Entity is Khoa khoa)
                {
                    string num6 = new string(Enumerable.Repeat(chars, 6).Select(s => s[rnd.Next(s.Length)]).ToArray());
                    khoa.MaKhoa = "KO" + "_" + num6;
                }
                else if (entry.Entity is DoanhThu doanhThu)
                {
                    DateTime now = DateTime.Now;
                    string today = now.ToString("ddMMyyyy_HHmmss");
                    doanhThu.MaDoanhThu = "DT" + today;
                }
                else if (entry.Entity is LopHoc lopHoc)
                {
                    DateTime now = DateTime.Now;
                    string today = now.ToString("ddMMyyyyHHmmss");
                    lopHoc.MaLop = "LH" + today;
                }
                else if (entry.Entity is GiangVien giangVien)
                {
                    DateTime now = DateTime.Now;
                    string num7 = new string(Enumerable.Repeat(chars, 6).Select(s => s[rnd.Next(s.Length)]).ToArray());
                    string num8 = new string(Enumerable.Repeat(chars, 6).Select(s => s[rnd.Next(s.Length)]).ToArray());
                    giangVien.MaGV = "GV" + "_" + num7 + "_" + num8;
                    giangVien.NgayHopTac = now;
                        
                }
                else if (entry.Entity is NhanVien nhanVien)
                {
                    DateTime now = DateTime.Now;
                    string num9 = new string(Enumerable.Repeat(chars, 6).Select(s => s[rnd.Next(s.Length)]).ToArray());
                    string num10 = new string(Enumerable.Repeat(chars, 6).Select(s => s[rnd.Next(s.Length)]).ToArray());
                    nhanVien.MaNV = "NV" + "_" + num9 + "_" + num10;
                    nhanVien.NgayVaoLam = now;

                }
                else if (entry.Entity is DangKy dangKy)
                {
                    DateTime now = DateTime.Now;
                    dangKy.NgayDK = now;

                }
                else if (entry.Entity is HocVien hocVien)
                {
                    string num11 = new string(Enumerable.Repeat(chars, 6).Select(s => s[rnd.Next(s.Length)]).ToArray());
                    string num12 = new string(Enumerable.Repeat(chars, 6).Select(s => s[rnd.Next(s.Length)]).ToArray());
                    hocVien.MaHV = "HV" + "_" + num11 + "_" + num12;
                }
                else if (entry.Entity is LienHe lienHe)
                {
                    DateTime now = DateTime.Now;
                    string today = now.ToString("ddMMyyyyHHmmss");
                    string num13 = new string(Enumerable.Repeat(chars, 6).Select(s => s[rnd.Next(s.Length)]).ToArray());
                    lienHe.MaLH = "LH" + today + "_" + num13;
                }
            }
            return base.SaveChanges();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DangKy>().HasKey(dk => new { dk.MaLop, dk.MaHV });
            modelBuilder.Entity<LichVang>().HasKey(lv => new { lv.MaLop, lv.MaHV });
            modelBuilder.Entity<Diem>().HasKey(bd => new { bd.MaMH, bd.MaHV, bd.MaLDiem });
            base.OnModelCreating(modelBuilder);

            //set no delete no action on LopHoc table
            modelBuilder.Entity<LopHoc>().HasOne(t => t.Khoas).WithMany().HasForeignKey(t => t.MaKhoa).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<LopHoc>().HasOne(t => t.MonHocs).WithMany().HasForeignKey(t => t.MaMH).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<LopHoc>().HasOne(t => t.DoanhThus).WithMany().HasForeignKey(t => t.MaDT).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<LopHoc>().HasOne(t => t.LichNghis).WithMany().HasForeignKey(t => t.MaLichNghi).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<LopHoc>().HasOne(t => t.GiangViens).WithMany().HasForeignKey(t => t.MaGV).OnDelete(DeleteBehavior.Restrict);

            //set default value
            modelBuilder.Entity<LoaiDiem>().Property(e => e.HeSo).HasDefaultValue(1);
        }
    }
}
