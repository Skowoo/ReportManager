using ReportManager.Resources;
using System.ComponentModel.DataAnnotations;

namespace ReportManager.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "CategoryNameRequiredErrorMessage")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "CategoryNameMaxLengthErrorMessage")]
        [MinLength(5, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "CategoryNameMinLengthErrorMessage")]
        public string CategoryName { get; set; }

        public ICollection<ReportEntry>? ReportEntries { get; set; }
    }
}
