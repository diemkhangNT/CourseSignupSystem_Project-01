namespace CourseSignupSystemServer.Models
{

    public class DoanhThu
    {
        [Key]
        public string MaDoanhThu { get; set; }

        [Required]
        [StringLength(7)]
        public string ThoiGian { get; set; } //thang 3/2023

        [Required]
        [StringLength(100)]
        public string? MoTa { get; set; }

        [Required]
        public double TongTien { get; set; } = 0.0;
    }
}
