namespace CourseSignupSystemServer.Models
{
    [Table("NienKhoa")]
    public class NienKhoa
    {
        [Key]
        public string MaNK { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNK { get; set; }

        [Required]
        [StringLength(9)]
        public string ThoiGian { get; set; }
        //2023-2024

    }
}
