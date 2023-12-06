using Microsoft.AspNetCore.Mvc;
using ReportManager.Data;
using ReportManager.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace ReportManager.Controllers
{
    public class HomeController(MainContext mainContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) : Controller
    {
        private readonly MainContext _mainContext = mainContext;

        private readonly UserManager<IdentityUser> _userManager = userManager;

        private readonly RoleManager<IdentityRole> _roleManager = roleManager;

        public IActionResult Index() => View();

        public IActionResult Privacy() => View();

        public IActionResult Debug() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        public async Task<IActionResult> CreateAllDb()
        {
            await DbSeeder.InitializeAll(_mainContext, _userManager, _roleManager);
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
