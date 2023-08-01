using CourseSignupSystemServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseSignupSystemClient.Controllers
{
    public class BoMonController : Controller
    {
        private readonly APIGateway aPIGateway;

        public BoMonController(APIGateway aPIGateway)
        {
            this.aPIGateway = aPIGateway;
        }

        public IActionResult Index()
        {
            List<BoMon> boMons;
            //API get will come
            boMons = aPIGateway.ListBoMons();
            return View(boMons);
        }

        public IActionResult Details(string id)
        {
            BoMon boMons;
            boMons = aPIGateway.GetBoMon(id);
            return View(boMons);
        }

        [HttpGet]
        public IActionResult Create()
        {
            BoMon BoMon = new BoMon();
            return View();
        }

        [HttpPost]
        public IActionResult Create(BoMon BoMon)
        {
            try
            {
                aPIGateway.CreateBoMon(BoMon);
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
            BoMon BoMon;
            BoMon = aPIGateway.GetBoMon(id);
            return View(BoMon);
        }

        [HttpPost]
        public IActionResult Edit(BoMon BoMon)
        {
            try
            {
                aPIGateway.UpdateBoMon(BoMon);
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
            BoMon BoMon;
            BoMon = aPIGateway.GetBoMon(id);
            return View(BoMon);
        }

        [HttpPost]
        public IActionResult Delete(BoMon BoMon)
        {
            try
            {
                aPIGateway.DeleteBoMon(BoMon.MaBM);
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
