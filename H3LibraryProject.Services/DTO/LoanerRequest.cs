using System.ComponentModel.DataAnnotations;

namespace H3LibraryProject.API.DTOs
{
    public class LoanerRequest
    {
        [Required]
        [StringLength(32, ErrorMessage = "Name max 32 chars")]
        public string Name { get; set; }

        [Required]
        [Range(1, 1000000000, ErrorMessage = "LoanerType-ID must be above 0")]
        public int LoanerTypeId { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Name max 32 chars")]
        public string Password { get; set; }
    }
}

