using CourseSignupSystemServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseSignupSystemClient.Controllers
{
    public class ChucVuController : Controller
    {
        private readonly APIGateway aPIGateway;

        public ChucVuController(APIGateway aPIGateway)
        {
            this.aPIGateway = aPIGateway;
        }

        public IActionResult Index()
        {
            List<ChucVu> chucVus;
            //API get will come
            chucVus = aPIGateway.ListChucVus();
            return View(chucVus);
        }

        public IActionResult Details(string id)
        {
            ChucVu chucVus = new ChucVu();
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ChucVu chucVu = new ChucVu();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ChucVu chucVu)
        {
            aPIGateway.CreateChucVu(chucVu);
           
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            ChucVu chucVu = new ChucVu();
            return View();
        }

        [HttpPost]
        public IActionResult Edit(ChucVu chucVu)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            ChucVu chucVu = new ChucVu();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(ChucVu chucVu)
        {
            return RedirectToAction("Index");
        }
    }
}
