namespace ReportManager.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public ICollection<ReportEntry> ReportEntries { get; set; }
    }
}
