﻿using CourseSignupSystemServer.Models;
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
            ChucVu chucVus;
            chucVus = aPIGateway.GetChucVu(id);
            return View(chucVus);
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
            try
            {
                aPIGateway.CreateChucVu(chucVu);
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
            ChucVu chucVu;
            chucVu = aPIGateway.GetChucVu(id);
            return View(chucVu);
        }

        [HttpPost]
        public IActionResult Edit(ChucVu chucVu)
        {
            try
            {
                aPIGateway.UpdateChucVu(chucVu);
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
            ChucVu chucVu;
            chucVu = aPIGateway.GetChucVu(id);
            return View(chucVu);
        }

        [HttpPost]
        public IActionResult Delete(ChucVu chucVu)
        {
            try
            {
                aPIGateway.DeleteChucVu(chucVu.MaCV);
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
