using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class OrnekController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = "viewbag ile veri tasıyorum..";

            ViewBag.Person = new { Id = "1", Name = "Eda", Age = 7 };

            ViewData["age"] = 30;

            TempData["tasi"] = "temp data ile sayfalar arası veri tasıyorum index1 - to index3";
            return View();
        }
        public IActionResult Index4()
        {
            var productList = new List<Product2>()
            {
                new(){Id=1,Name="Kalem"},
                new(){Id=2,Name="Silgi"},
                new(){Id=3,Name="Defer"},
                new(){Id=4,Name="Kalemlik"},

            };
            return View(productList);
        }


        public IActionResult Index3()
        {
            return View();
        }
        public IActionResult Index2()
        {
            //return View();
            return RedirectToAction("Index", "Ornek"); // bu sayede yonlendirme yaparız.index2 yazsak bile index sayfasına ulasırız

        }
        public IActionResult ParametreView(int id)
        {
            return RedirectToAction("JsonResultParametre", "Ornek", new { id = id });//yonlendirme yaptık ve id degeri aldık alınan bu degeri diger metootta da aldık ve esitledik.
        }
        public IActionResult JsonResultParametre(int id)
        {
            return Json(new { id = id });
        }


        public IActionResult ContentResult()
        {
            return Content("ContentResultDondu");
        }


        public IActionResult JsonResult()
        {
            return Json(new { Id = 1, name = "kalem", price = 150 });
        }



    }

  

    public class Product2
    {
        public int Id { get; set; }
        public string Name { get; set; }


    }

}
