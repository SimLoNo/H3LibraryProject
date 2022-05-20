using System.ComponentModel.DataAnnotations;

namespace H3LibraryProject.API.DTOs
{
    public class GenreRequest
    {
        [Required]
        [StringLength(32, ErrorMessage = "Name max 32 anslag")]
        public string Name { get; set; }


        [Required]
        [Range(1, 30, ErrorMessage = "LeasePeriod must be between 1 and 30 days")]
        public int LeasePeriod { get; set; }
    }
}