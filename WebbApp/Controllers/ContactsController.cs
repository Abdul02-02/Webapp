using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webbapp.Contexts;
using Webbapp.Models.Entities;

namespace Webbapp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IdentityContext _context;

        public ContactsController(IdentityContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Contact Us";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ContactEntity contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction("Respons");
            }
            return View(contact);
        }

        public IActionResult Respons()
        {
            return View();
        }
    }


}
