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
