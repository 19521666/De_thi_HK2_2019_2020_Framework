using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bai_Thi_Ky_02_2019_2020.Models;

namespace Bai_Thi_Ky_02_2019_2020.Controllers
{
    public class CongNhanController:Controller
    {
        public IActionResult LietKeCongNhanTheoSoTC()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ListByTime(int sotc)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(Bai_Thi_Ky_02_2019_2020.Models.DataContext)) as DataContext;
            return View(context.sqlListByTimeCongNhan(sotc));
        }

        public IActionResult ListCongNhan()
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(Bai_Thi_Ky_02_2019_2020.Models.DataContext)) as DataContext;
            return View(context.sqlListCongNhan());
        }


        public IActionResult ListByDCL(string MaDiemCachLy)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(Bai_Thi_Ky_02_2019_2020.Models.DataContext)) as DataContext;
            return View(context.sqlListCongNhanByDCL(MaDiemCachLy));
        }

        //[HttpGet("{controller}/{action}/{MaCongNhan}")]
        [HttpPost]
        public IActionResult Delete(string MaCongNhan)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(Bai_Thi_Ky_02_2019_2020.Models.DataContext)) as DataContext;
            context.sqlDeleteCongNhan(MaCongNhan);
            return RedirectToAction("ListByDCL","DiemCachLy");
        }

        //[HttpGet("{controller}/{action}/{MaCongNhan}")]
        [HttpPost]
        public IActionResult Details(string MaCongNhan)
        {
            if (MaCongNhan == null)
            {
                return NotFound();
            }
            DataContext context = HttpContext.RequestServices.GetService(typeof(Bai_Thi_Ky_02_2019_2020.Models.DataContext)) as DataContext;
            return View(context.sqlListCongNhan(MaCongNhan));
        }




    }
}
