using MandMWorldBank.Models;
using Microsoft.AspNetCore.Mvc;

namespace MandMWorldBank.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
