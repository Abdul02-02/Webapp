using Webbapp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Webbapp.Helpers.Services;


namespace Webbapp.Controllers;

public class HomeController : Controller
{
    private readonly ProductService _productService;


    public HomeController( ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var ViewModel = new HomeViewModel
        {
            BestCollection = new ColletionViewModel
            {
                Title = "Best Collections",
                Items = await _productService.GetAllByCategoryNameAsync("New")
            }
        };

        ViewData["Title"] = "Home";

        return View(ViewModel);
    }
}