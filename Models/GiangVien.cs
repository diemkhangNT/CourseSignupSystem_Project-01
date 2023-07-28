namespace CourseSignupSystemServer.Models
{
    [Table("GiangVien")]
    public class GiangVien
    {
        [Key]
        public string MaGV { get; set; }

        [Required]
        [StringLength(50)]
        public string TenGV { get; set; }

        [Required]
        [EmailAddress]
        [Remote("IsEmailValid", "GiangVien", AdditionalFields = "Email", ErrorMessage = "Email đã tồn tại!")]
        public string Email { get; set; }

        [Required]
        [Range(6, char.MaxValue)]
        public string Password { get; set; }

        [Required]
        [StringLength(10)]
        public int SDT { get; set; }

        [Required]
        public string DiaChi { get; set; }

        [Required]
        [Range(9, 12)]
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
        public DateTime NgayHopTac { get; set; }

        public bool TrangThaiHD { get; set; } = true;

        [Required]
        [ForeignKey("BoMons")]
        public string MaBM { get; set; }
        public virtual BoMon BoMons { get; set; }

        [Required]
        [ForeignKey("Luongs")]
        public string MaLuong { get; set; }
        public virtual Luong Luongs { get; set; }
    }
}
