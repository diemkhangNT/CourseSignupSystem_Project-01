
namespace CourseSignupSystemServer.Models
{
    public class NhanVien
    {
        [Key]
        public string MaNV { get; set; }

        [Required]
        [StringLength(50)] 
        public string TenNV { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(6,char.MaxValue)] 
        public string Password { get; set; }

        [Required]
        [StringLength(10)] 
        public int SDT { get; set; }

        [Required]
        public string DiaChi { get; set; }

        [Required]
        [Range(9,12)]
        public int CMND { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgaySinh { get; set; }

        public bool GioiTinh { get; set; } = true;

        public string? HinhDaiDien { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayVaoLam { get; set; }

        public bool TrangThaiHD { get; set; } = true;

        [Required]
        [ForeignKey("ChucVus")]
        public string MaCV { get; set; }
        public virtual ChucVu ChucVus { get; set; }

        [Required]
        [ForeignKey("Luongs")]
        public string MaLuong { get; set; }
        public virtual Luong Luongs { get; set; }
        
    }
}
