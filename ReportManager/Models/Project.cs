using System.ComponentModel.DataAnnotations;
using ReportManager.Resources;

namespace ReportManager.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ProjectNameRequiredErrorMessage")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ProjectNameMaxLengthErrorMessage")]
        [MinLength(10, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "ProjectNameMinLengthErrorMessage")]
        public string ProjectName { get; set; }

        public ICollection<ReportEntry> ReportEntries { get; set; }
    }
}
