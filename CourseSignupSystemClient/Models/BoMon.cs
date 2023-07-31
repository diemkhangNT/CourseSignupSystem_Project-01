namespace CourseSignupSystemServer.Models
{
    public class BoMon
    {
        [Key]
        public string MaBM { get; set; } 

        [Required]
        [StringLength(200)]
        public string TenBM { get; set; }
    }
}
