using System.ComponentModel.DataAnnotations;
using ReportManager.Resources;

namespace ReportManager.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ProjectNameRequiredErrorMessage")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ProjectNameMaxLengthErrorMessage")]
        [MinLength(5, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ProjectNameMinLengthErrorMessage")]
        [Display(ResourceType = typeof(Text), Name = "ProjectName")]
        public string ProjectName { get; set; } = default!;

        public ICollection<ReportEntry>? ReportEntries { get; set; }
    }
}
