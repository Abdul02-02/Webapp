using Microsoft.AspNetCore.Mvc;
using Webbapp.ViewModels;
using Webbapp.Helpers.Services;

namespace Webbapp.Controllers;

public class RegisterController : Controller
{

    private readonly AuthenticationService _authService;

    public RegisterController(AuthenticationService authService)
    {
        _authService = authService;
    }




    [HttpGet]
    public IActionResult Index()
    {

        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Index(UserRegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (await _authService.UserAldredyExistsAsync(model))
                ModelState.AddModelError("", "This email appear to be registred already..");

            if (await _authService.RegisterUserAsync(model))
                return RedirectToAction("Index", "Login");



        }
        return View(model);
    }
}
