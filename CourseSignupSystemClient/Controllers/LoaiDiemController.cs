using CourseSignupSystemServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseSignupSystemClient.Controllers
{
    public class LoaiDiemController : Controller
    {
        private readonly APIGateway aPIGateway;

        public LoaiDiemController(APIGateway aPIGateway)
        {
            this.aPIGateway = aPIGateway;
        }

        public IActionResult Index()
        {
            List<LoaiDiem> loaiDiems;
            //API get will come
            loaiDiems = aPIGateway.ListLoaiDiems();
            return View(loaiDiems);
        }

        public IActionResult Details(string id)
        {
            LoaiDiem loaiDiems;
            loaiDiems = aPIGateway.GetLoaiDiem(id);
            return View(loaiDiems);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoaiDiem loaiDiem = new LoaiDiem();
            return View();
        }

        [HttpPost]
        public IActionResult Create(LoaiDiem loaiDiem)
        {
            try
            {
                aPIGateway.CreateLoaiDiem(loaiDiem);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message); // Thêm lỗi vào ModelState
                return View(); // Trả về View để hiển thị lỗi
            }

        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            LoaiDiem loaiDiem;
            loaiDiem = aPIGateway.GetLoaiDiem(id);
            return View(loaiDiem);
        }

        [HttpPost]
        public IActionResult Edit(LoaiDiem loaiDiem)
        {
            try
            {
                aPIGateway.UpdateLoaiDiem(loaiDiem);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message); // Thêm lỗi vào ModelState
                return View(); // Trả về View để hiển thị lỗi
            }

        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            LoaiDiem loaiDiem;
            loaiDiem = aPIGateway.GetLoaiDiem(id);
            return View(loaiDiem);
        }

        [HttpPost]
        public IActionResult Delete(LoaiDiem loaiDiem)
        {
            try
            {
                aPIGateway.DeleteLoaiDiem(loaiDiem.MaLDiem);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message); // Thêm lỗi vào ModelState
                return View(); // Trả về View để hiển thị lỗi
            }

        }
    }
}
