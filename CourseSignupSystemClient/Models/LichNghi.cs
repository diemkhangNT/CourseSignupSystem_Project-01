namespace CourseSignupSystemServer.Models
{
    public class LichNghi
    {
        [Key]
        public string MaLN { get; set; } 

        [Required]
        public string TenLN { get; set; } 

        [Required]
        public string? MoTa { get; set; } 

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayBD { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayKT { get; set; }
    }
}
