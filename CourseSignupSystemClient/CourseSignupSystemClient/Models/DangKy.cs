

namespace CourseSignupSystemServer.Models
{
    public class DangKy
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
        public DateTime NgayDK { get; set; }

        public bool ThuHocPhi { get; set; } = false;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayThuHP { get; set; }
    }
}
