using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReportManager.Models;

namespace ReportManager.Data
{
    public class MainContext : IdentityDbContext
    {
        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder) 
            => base.OnModelCreating(builder);

        public DbSet<ReportEntry> Reports { get; set; }
        public DbSet<Category> Categories { get; set; }        
        public DbSet<Project> Projects { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
