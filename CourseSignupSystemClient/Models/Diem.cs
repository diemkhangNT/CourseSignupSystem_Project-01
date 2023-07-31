
namespace CourseSignupSystemServer.Models
{
    public class Diem
    {
        [Key]
        [ForeignKey("HocViens")]
        public string MaHV { get; set; }
        public virtual HocVien HocViens { get; set; }

        [Key]
        [ForeignKey("MonHocs")]
        public string MaMH { get; set; }
        public virtual MonHoc MonHocs { get; set; }

        [Key]
        [ForeignKey("LoaiDiems")]
        public string MaLDiem { get; set; }
        public virtual LoaiDiem LoaiDiems { get; set; }

        [Range(0.0, 10.0)]
        public double SoDiem { get; set; }
    }
}
