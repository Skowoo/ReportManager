using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReportManager.Models;

namespace ReportManager.Data
{
    public static class DbSeeder
    {
        static readonly string initialAdminCredentials = "Admin";
        static readonly string initialUserCredentials = "User";
        public const string AdminRoleName = "Administrator";
        public const string UserRoleName = "User";

        public async static Task InitializeDb(
            MainContext dbContext, 
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.Migrate();

            #region Initialize default users

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

            #endregion

            #region Initialize example data

            for (int i = 1; i <= 100; i++)
            {
                if (i <= 5)
                {
                    Category category = new()
                    {
                        CategoryName = $"ExampleCategory{i}"
                    };
                    dbContext.Add(category);

                    Project project = new()
                    {
                        ProjectName = $"ExampleProject{i}"
                    };
                    dbContext.Add(project);

                    Person person = new()
                    {
                        PersonName = $"ExamplePerson{i}"
                    };
                    dbContext.Add(person);

                    dbContext.SaveChanges();
                }

                Random rnd = new();

                int upperRndLimit = dbContext.Categories.Count() + 1;

                ReportEntry reportEntry = new()
                {
                    ReportTitle = $"ExampleTitle{i}",
                    ReportDescription = $"Example problem description created automatically by rather poorly designed generator in it's {i} iteration :)",
                    CategoryId = rnd.Next(1, upperRndLimit),
                    ProjectId = rnd.Next(1, upperRndLimit),
                    PersonId = rnd.Next(1, upperRndLimit),
                };

                if (rnd.Next(0, 10) < 2)
                    reportEntry.PersonId = null;

                dbContext.Add(reportEntry);

                dbContext.SaveChanges();
            }
            #endregion
        }
    }
}
