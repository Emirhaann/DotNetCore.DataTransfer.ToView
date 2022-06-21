using DotNetCore.DataTransfer.ToView.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNetCore.DataTransfer.ToView.Controllers
{
    public class ProductController : Controller
    {
        public List<Product> GetProductsList
        {
            get
            {
                List<Product> products = new List<Product>();
                products.Add(new Product { Id = 1, ProductName = "Elma", Price = 21, Stock = 10 });
                products.Add(new Product { Id = 2, ProductName = "Armut", Price = 22, Stock = 10 });
                products.Add(new Product { Id = 3, ProductName = "Karpuz", Price = 23, Stock = 10 });
                products.Add(new Product { Id = 4, ProductName = "Kavun", Price = 24, Stock = 10 });

                return products;
            }

        }

        public IActionResult List()
        {
            TempData["ProductList"] = JsonConvert.SerializeObject(GetProductsList);
            ViewBag.ProductList = JsonConvert.SerializeObject(GetProductsList); ;
            ViewData["prodcustList"] = JsonConvert.SerializeObject(GetProductsList); ;

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var tempDataveri = TempData["ProdcustList"];
            var viewBagDataVeri = ViewBag.ProductList;
            var viewDataVeri = ViewData["productsList"];

            return View();
        }
    }
}
