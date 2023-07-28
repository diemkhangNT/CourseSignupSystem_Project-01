namespace CourseSignupSystemServer.Interfaces
{
    public interface IExistAlreadyService
    {
        bool IsEmailNVUnique(string emailNV); // email nhân viên
        bool IsEmailHVUnique(string emailHV); // email học viên
        bool IsEmailGVUnique(string emailGV); // email giảng viên
        bool IsTenCVUnique(string tenCV); // tên chức vụ của nhân viên
        bool IsCMNDnvUnique(int cmndNV); // chứng minh nhân dân của nhân viên
        bool IsCMNDgvUnique(int cmndGV); // chứng minh nhân dân của giảng viên
        bool IsTenLDiemUnique(string tenLDiem); // tên loại điểm
        bool IsTenMHUnique(string tenMH); // tên môn học
        bool IsTenBMUnique(string tenBM); // tên bộ môn
        bool IsTenKhoaUnique(string tenKhoa); // tên khoa
    }
}
