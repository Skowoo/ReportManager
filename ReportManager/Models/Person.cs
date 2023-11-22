using System.ComponentModel.DataAnnotations;
using ReportManager.Resources;

namespace ReportManager.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "PersonNameRequiredErrorMessage")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "PersonNameMaxLengthErrorMessage")]
        [MinLength(5, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "PersonNameMinLengthErrorMessage")]
        [Display(ResourceType = typeof(Text), Name = "PersonName")]
        public string PersonName { get; set; }

        public ICollection<ReportEntry>? ReportEntries { get; set;}
    }
}
