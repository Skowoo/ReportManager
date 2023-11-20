namespace ReportManager.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        public string Name { get; set; }

        public ICollection<ReportEntry> ReportEntries { get; set;}
    }
}
