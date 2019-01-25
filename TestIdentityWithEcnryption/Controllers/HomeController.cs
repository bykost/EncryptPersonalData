using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataProtector _protector;
        private readonly UserManager<User> _userManager;

        private string _password = "paSsw0rd!";

        public HomeController (IDataProtectionProvider provider, UserManager<User> userManager)
        {
            _protector = provider.CreateProtector("DataProtector.v1");
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string email)
        {
            var user = await _userManager.FindByEmailAsync(email ?? "test@mail.com");
            
            ViewBag.UserName = user.UserName;
            ViewBag.Password = _password;
            ViewBag.ProtectedString = user.ProtectedString;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string Protect(string data)
        {
            string protectedData = _protector.Protect(data);
            return protectedData;
        }

        public string Unprotect(string data)
        {
            string unProtectedData = _protector.Unprotect(data);
            return unProtectedData;               
        }

        public async Task<IActionResult> AddUser(string email, string sec)
        {
            var result = await _userManager.CreateAsync(new User
            {
                UserName = email,
                Email = email,
                City = "New York",
                ProtectedString = sec,
                PhoneNumber = "123465"
            }, _password);

            return RedirectToAction("Index");
        }
    }
}
