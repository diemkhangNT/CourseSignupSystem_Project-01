
namespace CourseSignupSystemServer.Models
{
    public class Luong
    {
        [Key]
        public string MaLuong { get; set; }
        
        [Required]
        [Range(0,100000000)]
        public double TienThuong { get; set; } = 0.0;
        
        [Required]
        [Range(0, 100000000)]
        public double PhuCap { get; set; } = 0.0;
        
        [Required]
        [Range(0, 100000000)]
        public double ThucLanh { get; set; } = 0.0;
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayNhan { get; set; }

        [StringLength(1000, MinimumLength = 4)]
        public string? GhiChu { get; set; }


    }
}
