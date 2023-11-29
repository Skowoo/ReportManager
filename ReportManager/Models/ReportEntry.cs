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
        [Display(ResourceType = typeof(Text), Name = "ReportTitle")]
        public string ReportTitle { get; set; } = default!;

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ReportDescRequiredErrorMessage")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ReportDescMaxLengthErrorMessage")]
        [MinLength(20, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ReportDescMinLengthErrorMessage")]
        [Display(ResourceType = typeof(Text), Name = "ReportDescription")]
        public string ReportDescription { get; set; } = default!;

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ReportCatIdRequiredErrorMessage")]
        [Display(ResourceType = typeof(Text), Name = "CategoryId")]
        public int CategoryId { get; set; }
        [Display(ResourceType = typeof(Text), Name = "CategoryId")]
        public Category? Category { get; set; }

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ReportProjIdRequiredErrorMessage")]
        [Display(ResourceType = typeof(Text), Name = "ProjectId")]
        public int ProjectId { get; set; }
        public Project? Project { get; set; }

        [Display(ResourceType = typeof(Text), Name = "PersonId")]
        public int? PersonId { get; set; }
        [Display(ResourceType = typeof(Text), Name = "PersonId")]
        public Person? Person { get; set; }
    }
}
