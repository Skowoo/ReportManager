using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReportManager.Models;

namespace ReportManager.Data
{
    public static class DbInitializer
    {
        static string initialAdminCredentials = "Admin";
        static string initialUserCredentials = "User";
        public const string AdminRoleName = "Administrator";
        public const string UserRoleName = "User";

        public static void InitializeAll(
            MainContext mainContext, 
            IdentityContext IdentityContext, 
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            InitializeIdentityDbAsync(IdentityContext, userManager, roleManager);
            InitializeMainDb(mainContext);
        }

        public async static void InitializeIdentityDbAsync(
            IdentityContext identityContext,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            identityContext.Database.EnsureDeleted();
            identityContext.Database.Migrate();

            var newAdmin = new IdentityUser
            {
                UserName = initialAdminCredentials
            };
            await userManager.CreateAsync(newAdmin, initialAdminCredentials);
            await roleManager.CreateAsync(new IdentityRole(AdminRoleName));
            await userManager.AddToRoleAsync(newAdmin, AdminRoleName);

            var newUser = new IdentityUser
            {
                UserName = initialUserCredentials
            };
            await userManager.CreateAsync(newUser, initialUserCredentials);
            await roleManager.CreateAsync(new IdentityRole(UserRoleName));
            await userManager.AddToRoleAsync(newUser, UserRoleName);
        }

        public static void InitializeMainDb(MainContext mainContext)
        {
            mainContext.Database.EnsureDeleted();
            mainContext.Database.EnsureCreated();

            for (int i =  1; i <= 10; i++)
            {
                if (i <= 5)
                {
                    Category category = new Category()
                    {
                        CategoryName = $"ExampleCategory{i}"
                    };
                    mainContext.Add(category);

                    Project project = new Project()
                    {
                        ProjectName = $"ExampleProject{i}"
                    };
                    mainContext.Add(project);

                    Person person = new Person()
                    {
                        PersonName = $"ExamplePerson{i}"
                    };
                    mainContext.Add(person);

                    mainContext.SaveChanges();
                }

                Random rnd = new();

                int upperRndLimit = mainContext.Categories.Count() + 1;

                ReportEntry reportEntry = new ReportEntry()
                {
                    ReportTitle = $"ExampleTitle{i}",
                    ReportDescription = $"Example problem description created automatically by rather poorly designed generator in it's {i} iteration :)",
                    CategoryId = rnd.Next(1, upperRndLimit),
                    ProjectId = rnd.Next(1, upperRndLimit),
                    PersonId = rnd.Next(1, upperRndLimit),
                };

                mainContext.Add(reportEntry);

                mainContext.SaveChanges();
            }
        }
    }
}
