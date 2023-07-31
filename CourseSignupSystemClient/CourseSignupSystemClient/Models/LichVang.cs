namespace CourseSignupSystemServer.Models
{
    public class LichVang
    {
        [Key]
        [ForeignKey("HocViens")]
        public string MaHV { get; set; }
        public virtual HocVien HocViens { get; set; }

        [Key]
        [ForeignKey("Lops")]
        public string MaLop { get; set; }
        public virtual LopHoc Lops { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayVang { get; set; }

        [Required]
        [Range(4,100)]
        public string LyDo { get; set; }   
    }
}
