using Microsoft.AspNetCore.Mvc;
using ReportManager.Data;
using ReportManager.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace ReportManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly MainContext _mainContext;

        private readonly IdentityContext _identityContext;

        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(
            ILogger<HomeController> logger, 
            MainContext mainContext, 
            IdentityContext identityContext, 
            UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _mainContext = mainContext;
            _identityContext = identityContext;
            _userManager = userManager;
        }

        public IActionResult CreateDb()
        {
            DbInitializer.InitializeAll(_mainContext, _identityContext, _userManager);
            return View("Index");
        }

        public IActionResult Index()
        {
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
    }
}
