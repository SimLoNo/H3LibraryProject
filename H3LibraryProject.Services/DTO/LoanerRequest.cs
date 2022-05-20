using System.ComponentModel.DataAnnotations;

namespace H3LibraryProject.API.DTOs
{
    public class LoanerRequest
    {
        [Required]
        [StringLength(32, ErrorMessage = "Name max 32 chars")]
        public string Name { get; set; }
        [Required]
        [StringLength(32, ErrorMessage = "Fornavn max 32 anslag")]
        public string LName { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Efternavn max 32 anslag")]
        public string FName { get; set; }

        [StringLength(32, ErrorMessage = "Mellemnavn max 32 anslag")]
        public string MName { get; set; } //Funktionelt implicit nullable, da en string bare kan være ""

        [Required]
        [Range(0, 3000, ErrorMessage = "Fødselsår skal være mellem 0 og 3000")]
        public int BYear { get; set; }

        [Range(0, 3000, ErrorMessage = "Dødsår skal være mellem 0 og 3000")]
        public int? DYear { get; set; } //Nullable

        [Required]
        [StringLength(32, ErrorMessage = "Nationalitet max 32 anslag")]
        public string Nationality { get; set; }
    }
}
