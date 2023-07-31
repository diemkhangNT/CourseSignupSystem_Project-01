namespace CourseSignupSystemServer.Models
{
    public class Khoa
    {
        [Key]
        public string MaKhoa { get; set; }

        [Required]
        [StringLength(70)]
        public string TenKhoa { get; set; }

        [Required]
        [ForeignKey("NienKhoas")]
        public string MaNienKhoa { get; set; }
        public virtual NienKhoa NienKhoas { get; set; }
    }
}
