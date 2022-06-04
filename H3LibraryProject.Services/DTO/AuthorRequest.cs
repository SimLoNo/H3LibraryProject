using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace H3LibraryProject.API.DTOs
{
    public class AuthorRequest
    {

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
        [Range(0, 3000, ErrorMessage = "Nationalitet mellem 0 og 3000")]
        public int NationalityId { get; set; }

        public List<int> TitlesList { get; set; }

    }
}

