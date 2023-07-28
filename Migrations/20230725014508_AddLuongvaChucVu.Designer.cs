﻿// <auto-generated />
using System;
using CourseSignupSystemServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseSignupSystemServer.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20230725014508_AddLuongvaChucVu")]
    partial class AddLuongvaChucVu
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CourseSignupSystemServer.Models.ChucVu", b =>
                {
                    b.Property<string>("MaCV")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TenCV")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("MaCV");

                    b.ToTable("ChucVu");
                });

            modelBuilder.Entity("CourseSignupSystemServer.Models.Luong", b =>
                {
                    b.Property<string>("MaLuong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("NgayNhan")
                        .HasColumnType("datetime2");

                    b.Property<double>("PhuCap")
                        .HasColumnType("float");

                    b.Property<double>("ThucLanh")
                        .HasColumnType("float");

                    b.Property<double>("TienThuong")
                        .HasColumnType("float");

                    b.HasKey("MaLuong");

                    b.ToTable("Luong");
                });

            modelBuilder.Entity("CourseSignupSystemServer.Models.NhanVien", b =>
                {
                    b.Property<string>("MaNV")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CMND")
                        .HasColumnType("int");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("GioiTinh")
                        .HasColumnType("bit");

                    b.Property<string>("HinhDaiDien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaCV")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaLuong")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayVaoLam")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SDT")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("TenNV")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("TrangThaiHD")
                        .HasColumnType("bit");

                    b.HasKey("MaNV");

                    b.HasIndex("MaCV");

                    b.HasIndex("MaLuong");

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("CourseSignupSystemServer.Models.NhanVien", b =>
                {
                    b.HasOne("CourseSignupSystemServer.Models.ChucVu", "ChucVus")
                        .WithMany()
                        .HasForeignKey("MaCV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseSignupSystemServer.Models.Luong", "Luongs")
                        .WithMany()
                        .HasForeignKey("MaLuong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChucVus");

                    b.Navigation("Luongs");
                });
#pragma warning restore 612, 618
        }
    }
}
