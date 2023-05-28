using Microsoft.AspNetCore.Mvc;
using Webbapp.Contexts;
using Webbapp.Helpers.Services;

namespace Webbapp.Controllers
{



    public class ProductsController : Controller
    {
        private readonly IdentityContext _Context;
        private readonly ProductService _productService;
        public ProductsController(IdentityContext Context, ProductService productService)
        {
            _Context = Context;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_Context.Products.ToList());
        }

        public IActionResult Search()
        {
            ViewData["Title"] = "Search for products";
            return View();
        }




        public async Task<IActionResult> Details(string articleNumber)
        {
            var item = await _productService.GetAsync(articleNumber);
            return View(item);
        }
    }
}
