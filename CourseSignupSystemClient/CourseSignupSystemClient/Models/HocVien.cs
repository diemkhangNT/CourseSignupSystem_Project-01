﻿namespace CourseSignupSystemServer.Models
{
    public class HocVien
    {
        [Key]
        public string MaHV { get; set; }

        [Required]
        [StringLength(50)]
        public string TenHV { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(6, char.MaxValue)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgaySinh { get; set; }

        [Required]
        [StringLength (50)]
        public string PhuHuynh { get; set; }

        [Required]
        [StringLength (10)]
        public int SDTLienLac { get; set; }

        [Required]
        public string AnhDaiDien { get; set; }
    }
}
