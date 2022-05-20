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

        [Range(0, 3000, ErrorMessage = "Dødsår skal være mellem 0 og 3000")]
        public int? DYear { get; set; } //Nullable

        [Required]
        [StringLength(32, ErrorMessage = "Nationalitet max 32 anslag")]
        public string Nationality { get; set; }
    }
}