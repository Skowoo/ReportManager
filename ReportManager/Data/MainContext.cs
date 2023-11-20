using Microsoft.EntityFrameworkCore;
using ReportManager.Models;

namespace ReportManager.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
        }

        public DbSet<ReportEntry> Tickets { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ReportEntry> ReportEntries { get; set; }
    }
}
