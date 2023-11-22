using Microsoft.AspNetCore.Mvc;
using ReportManager.Data;
using ReportManager.Models;
using System.Diagnostics;

namespace ReportManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly MainContext _mainContext;

        private readonly IdentityContext _identityContext;

        public HomeController(ILogger<HomeController> logger, MainContext mainContext, IdentityContext identityContext)
        {
            _logger = logger;
            _mainContext = mainContext;
            _identityContext = identityContext;
        }

        public IActionResult CreateDb()
        {
            DbInitializer.InitializeAll(_mainContext, _identityContext);
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
