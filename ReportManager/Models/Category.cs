namespace ReportManager.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public ICollection<ReportEntry> ReportEntries { get; set; }
    }
}
