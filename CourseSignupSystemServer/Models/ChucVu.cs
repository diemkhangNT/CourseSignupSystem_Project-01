
using System.Text.Json.Serialization;

namespace CourseSignupSystemServer.Models
{
    [Table("ChucVu")]
    public class ChucVu
    {
        [Key]
        [ScaffoldColumn(false)]
        public string MaCV { get; set; }

        [Required]
        [StringLength(75)]
        public string TenCV { get; set; }

        [StringLength(100)]
        public string? MoTa { get; set; }
    }
}