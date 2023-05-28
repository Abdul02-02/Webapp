using Webbapp.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Webbapp.Contexts;

namespace Webbapp.Controllers;

[Authorize(Roles = "admin")]
public class AdminController : Controller
{
    private readonly IdentityContext _identityContext;

    public AdminController(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }

    [HttpGet("admin")]
    public IActionResult Index()
    {
        return View(_identityContext.Users.ToList());

    }
}
