using Microsoft.AspNetCore.Mvc;
using ReportManager.Data;
using ReportManager.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace ReportManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly MainContext _mainContext;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(MainContext mainContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!mainContext.Database.CanConnect())
                DbSeeder.InitializeDb(mainContext, userManager, roleManager).Wait();

            _mainContext = mainContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index() => View();

        public IActionResult Privacy() => View();

        public IActionResult Debug() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        public async Task<IActionResult> CreateAllDb()
        {
            await DbSeeder.InitializeDb(_mainContext, _userManager, _roleManager);
            return Redirect("../ReportEntries/Index");
        }

        public IActionResult DeleteAllDb() 
        {
            if (_mainContext.Database.CanConnect())
                _mainContext.Database.EnsureDeleted();

            return View("Debug");
        }
    }
}
