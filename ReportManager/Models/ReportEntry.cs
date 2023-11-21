using System.ComponentModel.DataAnnotations;
using ReportManager.Resources;

namespace ReportManager.Models
{
    public class ReportEntry
    {
        public int ReportEntryId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ReportTitleRequiredErrorMessage")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ReportTitleMaxLengthErrorMessage")]
        [MinLength(5, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ReportTitleMinLengthErrorMessage")]
        public string ReportTitle { get; set; }

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ReportDescRequiredErrorMessage")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ReportDescMaxLengthErrorMessage")]
        [MinLength(20, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ReportDescMinLengthErrorMessage")]
        public string ReportDescription { get; set; }

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ReportCatIdRequiredErrorMessage")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ReportProjIdRequiredErrorMessage")]
        public int ProjectId { get; set; }
        public Project? Project { get; set; }

        public int? PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
