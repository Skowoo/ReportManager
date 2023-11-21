using System.ComponentModel.DataAnnotations;
using ReportManager.Resources;

namespace ReportManager.Models
{
    public class ReportEntry
    {
        public int ReportEntryId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "TicketTitleRequiredErrorMessage")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "TicketTitleMaxLengthErrorMessage")]
        [MinLength(5, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "TicketTitleMinLengthErrorMessage")]
        public string TicketTitle { get; set; }

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "TicketDescRequiredErrorMessage")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "TicketDescMaxLengthErrorMessage")]
        [MinLength(50, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "TicketDescMinLengthErrorMessage")]
        public string TicketDescription { get; set; }

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "TicketCatIdRequiredErrorMessage")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "TicketProjIdRequiredErrorMessage")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int? PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
