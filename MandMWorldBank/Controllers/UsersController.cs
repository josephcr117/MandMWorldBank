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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                return RedirectToAction("Dashboard", new { id = user.Id });
            }
            else
            {
                ViewBag.Error = "Invalid Username or Password.";
                return View();
            }
        }

        public IActionResult Dashboard(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Transfer()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            ViewBag.SenderId = userId;
            return View();
        }

        [HttpPost]
        public IActionResult Transfer(int recipientId, decimal amount)
        {
            var senderId = HttpContext.Session.GetInt32("UserId");

            if (senderId == null)
            {
                return RedirectToAction("Login");
            }

            var sender = _context.Users.FirstOrDefault(u => u.Id == senderId);
            var recipient = _context.Users.FirstOrDefault(u => u.Id == recipientId);

            if (sender == null || recipient == null)
            {
                ViewBag.Error = "Invalid sender or recipient account";
                return View();
            }

            if (sender.Balance < amount)
            {
                ViewBag.Error = "Insufficient Funds.";
                return View();
            }

            sender.Balance -= amount;
            recipient.Balance += amount;

            var transaction = new Transaction
            {
                SenderId = senderId.Value,
                RecipientId = recipientId,
                Amount = amount
            };
            _context.Transactions.Add(transaction);

            _context.SaveChanges();

            ViewBag.Success = $"Transfer of {amount} to {recipient.Username} was successful!";
            ViewBag.SenderId = senderId;
            return View();
        }

        public IActionResult TransactionHistory(int userId)
        {
            var transactions = _context.Transactions
            .Where(t => t.SenderId == userId || t.RecipientId == userId)
            .OrderByDescending(t => t.TransactionDate)
            .ToList();

            ViewBag.UserId = userId;
            return View(transactions);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
