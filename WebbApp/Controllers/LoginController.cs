using Microsoft.AspNetCore.Mvc;
using Webbapp.Helpers.Services;
using Webbapp.ViewModels;

namespace Webbapp.Controllers;

public class LoginController : Controller
{
    private readonly AuthenticationService _authService;

    public LoginController(AuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpGet]
    public IActionResult Index(string ReturnUrl = null!)
    {
        var model = new UserLoginViewModel();
        if (ReturnUrl != null)
            model.ReturnUrl = ReturnUrl;

        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> Index(UserLoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (await _authService.LoginAsync(model))
                return LocalRedirect(model.ReturnUrl);

            ModelState.AddModelError("", "Invalid credentials..please try again");
        }

        return View(model);
    }
}
