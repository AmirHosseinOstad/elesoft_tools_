using ToolsOfElesoftVersion2025.Models;
using ToolsOfElesoftVersion2025.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToolsOfElesoftV2025.Models;

namespace ToolsOfElesoftVersion2025.Controllers
{
    [LayoutClass]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //تعریف اشیا از کوکی
        CookieOptions cookieOptions = new CookieOptions
        {
            Expires = DateTime.Now.AddYears(2),
            Secure = true,
            HttpOnly = true
        };

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
