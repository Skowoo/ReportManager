using ReportManager.Resources;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace ReportManager.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "CategoryNameRequiredErrorMessage")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "CategoryNameMaxLengthErrorMessage")]
        [MinLength(5, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "CategoryNameMinLengthErrorMessage")]
        [Display(ResourceType = typeof(Text), Name = "CategoryName")]
        public string CategoryName { get; set; } = default!;

        public ICollection<ReportEntry>? ReportEntries { get; set; }
    }
}
