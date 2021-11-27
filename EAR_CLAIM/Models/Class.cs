using System.ComponentModel.DataAnnotations;

namespace EAR_CLAIM.Models
{
    public class Class
    {
        [Required]
        public string userId { get; set; }
        [Required]
        public string worksheetReference { get; set; }
        [Required]
        public string subclassNumber { get; set; }
        [Required]
        public string reasonForStatusChange { get; set; }
    }
}
