using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using ReportManager.Models;

namespace ReportManager.Data
{
    public static class DbInitializer
    {
        static MainContext? _mainContext;

        static IdentityContext? _identityContext;

        static UserManager<IdentityUser>? _userManager;

        public static void InitializeAll(MainContext mainContext, IdentityContext IdentityContext, UserManager<IdentityUser> userManager)
        {
            InitializeIdentityDb(IdentityContext, userManager);
            InitializeMainDb(mainContext);
        }

        public async static void InitializeIdentityDb(IdentityContext context, UserManager<IdentityUser> userManager)
        {
            _identityContext = context;
            _identityContext.Database.EnsureDeleted();
            _identityContext.Database.Migrate();
            
            _userManager = userManager;

            //Create user with IdentityUser class
            var newUser = new IdentityUser
            {
                UserName = "Tester"
            };

            //Create user in database
            await _userManager.CreateAsync(newUser, "Tester");
        }

        public static void InitializeMainDb(MainContext context)
        {
            _mainContext = context;

            _mainContext.Database.EnsureDeleted();
            _mainContext.Database.EnsureCreated();

            for (int i =  1; i <= 10; i++)
            {
                if (i <= 5)
                {
                    Category category = new Category()
                    {
                        CategoryName = $"ExampleCategory{i}"
                    };
                    _mainContext.Add(category);

                    Project project = new Project()
                    {
                        ProjectName = $"ExampleProject{i}"
                    };
                    _mainContext.Add(project);

                    Person person = new Person()
                    {
                        PersonName = $"ExamplePerson{i}"
                    };
                    _mainContext.Add(person);

                    _mainContext.SaveChanges();
                }

                Random rnd = new();

                ReportEntry reportEntry = new ReportEntry()
                {
                    ReportTitle = $"ExampleTitle{i}",
                    ReportDescription = $"Example problem description created automatically by rather poorly designed generator in it's {i} iteration :)",
                    CategoryId = rnd.Next(1, _mainContext.Categories.Count()),
                    ProjectId = rnd.Next(1, _mainContext.Projects.Count()),
                    PersonId = rnd.Next(1, _mainContext.Persons.Count()),
                };

                _mainContext.Add(reportEntry);

                _mainContext.SaveChanges();
            }
        }
    }
}
