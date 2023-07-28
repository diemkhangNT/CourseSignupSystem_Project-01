using CourseSignupSystemServer.Data;
using CourseSignupSystemServer.Interfaces;
using CourseSignupSystemServer.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using static NHibernate.Engine.Query.CallableParser;

namespace CourseSignupSystemServer.Services
{
    public class ExistAlreadyService : IExistAlreadyService
    {
        private readonly ApiDbContext _dbContext;

        public ExistAlreadyService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool IsCMNDnvUnique(int cmndNV)
        {
            return _dbContext.NhanViens.Any(a => a.CMND == cmndNV);
            //throw new NotImplementedException();
        }

        public bool IsCMNDgvUnique(int cmndGV)
        {
            return _dbContext.GiangViens.Any(a => a.CMND == cmndGV);
            //throw new NotImplementedException();
        }

        public bool IsEmailNVUnique(string emailNV)
        {
            return _dbContext.NhanViens.Any(u => u.Email == emailNV);
            //throw new NotImplementedException();
        }

        public bool IsEmailHVUnique(string emailHV)
        {
            return _dbContext.HocViens.Any(u => u.Email == emailHV);
            //throw new NotImplementedException();
        }

        public bool IsEmailGVUnique(string emailGV)
        {
            return _dbContext.GiangViens.Any(u => u.Email == emailGV);
            //throw new NotImplementedException();
        }

        public bool IsTenBMUnique(string tenBM)
        {
            return _dbContext.BoMons.Any(u => u.TenBM == tenBM);
            //throw new NotImplementedException();
        }

        public bool IsTenCVUnique(string tenCV)
        {
            return _dbContext.ChucVus.Any(u => u.TenCV == tenCV);
            //throw new NotImplementedException();
        }

        public bool IsTenKhoaUnique(string tenKhoa)
        {
            return _dbContext.Khoas.Any(u => u.TenKhoa == tenKhoa);
            //throw new NotImplementedException();
        }

        public bool IsTenLDiemUnique(string tenLDiem)
        {
            return _dbContext.LoaiDiems.Any(u => u.TenLDiem == tenLDiem);
            //throw new NotImplementedException();
        }

        public bool IsTenMHUnique(string tenMH)
        {
            return _dbContext.MonHocs.Any(u => u.TenMH == tenMH);
            //throw new NotImplementedException();
        }

    }
}
