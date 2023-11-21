using ReportManager.Resources;
using System.ComponentModel.DataAnnotations;

namespace ReportManager.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "CategoryNameRequiredErrorMessage")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "CategoryNameMaxLengthErrorMessage")]
        [MinLength(10, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "CategoryNameMinLengthErrorMessage")]
        public string CategoryName { get; set; }

        public ICollection<ReportEntry> ReportEntries { get; set; }
    }
}
