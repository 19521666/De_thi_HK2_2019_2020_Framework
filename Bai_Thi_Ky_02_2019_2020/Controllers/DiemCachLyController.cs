using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bai_Thi_Ky_02_2019_2020.Models;

namespace Bai_Thi_Ky_02_2019_2020.Controllers
{
    public class DiemCachLyController: Controller
    {
        public IActionResult ThemDCL()
        {
            return View();
        }

        [HttpPost]
        public string AddDCL(Diemcachly diemcachly)
        {
            int count;
            DataContext context = HttpContext.RequestServices.GetService(typeof(Bai_Thi_Ky_02_2019_2020.Models.DataContext)) as DataContext;
                count = context.sqlInsertDCL(diemcachly);
                if (count == 1)
                {
                    return "Them thanh cong";
                }
                return "Them that bai";

        }

        public IActionResult ListDiemCachLy()
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(Bai_Thi_Ky_02_2019_2020.Models.DataContext)) as DataContext;
            return View(context.sqlListDiemCachLy());
        }
    }
}
