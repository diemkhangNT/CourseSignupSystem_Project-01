

namespace CourseSignupSystemServer.Models
{
    public class LienHe
    {
        [Key]
        public string MaLH { get; set; }
        [Required]
        [StringLength(50)]
        public string TieuDe { get; set; }
        [Required]
        [StringLength (200)]
        public string NoiDung { get; set; }
        [Required]
        public DateTime NgayLH { get; set; }
        [Required]
        [ForeignKey("HocViens")]
        public string MaHV { get; set; }
        public virtual HocVien HocViens { get; set; }   

    }
}
