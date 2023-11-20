using System.ComponentModel.DataAnnotations;

namespace ReportManager.Models
{
    public class ReportEntry
    {
        public int ReportEntryId { get; set; }

        public string TicketTitle { get; set; }

        public string TicketDescription { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }   
        
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
