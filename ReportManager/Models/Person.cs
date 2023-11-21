using System.ComponentModel.DataAnnotations;
using ReportManager.Resources;

namespace ReportManager.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "PersonNameRequiredErrorMessage")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "PersonNameMaxLengthErrorMessage")]
        [MinLength(10, ErrorMessageResourceType = typeof(Text), ErrorMessageResourceName = "PersonNameMinLengthErrorMessage")]
        public string PersonName { get; set; }

        public ICollection<ReportEntry> ReportEntries { get; set;}
    }
}
