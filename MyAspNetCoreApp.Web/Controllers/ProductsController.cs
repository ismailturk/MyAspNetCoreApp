using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private ExampleTurkcellContext _context;
        private readonly ProductRepository _productRepository;
     
        public ProductsController(ExampleTurkcellContext context)
        {
            _productRepository = new ProductRepository();
           _context = context;

            if (!_context.Products.Any())
            {
                _context.Products.Add(new Product() { Name = "yenieklendi", Price = 500, Stock = 1500 });
                _context.SaveChanges();

            }

        }
          

        public IActionResult IndexProduct()
        {
            var products = _context.Products.ToList();
           
            return View(products);
        }
        public IActionResult Remove(int id)
        {
            var product= _context.Products.Find(id);
            _context.Products.Remove(product);

            _context.SaveChanges();
            
            return RedirectToAction("IndexProduct");
        }
       
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.ColorSelect = new SelectList(new List<ColorList>()
            {
               new(){Data="Mavi",Value="Mavi"},
                new(){Data="Kırmızı",Value="Kırmızı"},
                 new(){Data="Siyah",Value="Siyah"}
            },"Value","Data");
            return View();

        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            //1.Yontem (Form ile veri alma)
            //var name = HttpContext.Request.Form["Name"]; // buradaki isimler olusturdugumuz forn icierisindeki inputlardan gelmektedir. orada da name price gibi isimler verdik
            //var price = decimal.Parse(HttpContext.Request.Form["Price"]);
            //var stock = int.Parse(HttpContext.Request.Form["Stock"]);
            //var color = HttpContext.Request.Form["Color"];

            //Product product= new Product() { Name=name,Price=price,Stock=stock,Color=color};
            //_context.Products.Add(product);

            //2. Yontem olarak ise methoddan parametre ile alırız(parametreler formdaki namelerle eslesir)
            // Product newProduct= new Product() { Name=Name,Price=Price,Stock=Stock,Color=Color};
            //_context.Products.Add(newProduct);  
            _context.Products.Add(product);
            TempData["status"] = "Product successfully added";
            _context.SaveChanges();



            return RedirectToAction("IndexProduct");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);
            ViewBag.ColorSelect = new SelectList(new List<ColorList>()
            {
               new(){Data="Mavi",Value="Mavi"},
                new(){Data="Kırmızı",Value="Kırmızı"},
                 new(){Data="Siyah",Value="Siyah"}
            }, "Value", "Data",product.Color);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            TempData["status"] = "Product successfully updated";
            return RedirectToAction("IndexProduct");

        }
    }
}
