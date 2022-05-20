using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace H3LibraryProject.API.DTOs
{
    public class TitleRequest
    {
        [Required]
        [StringLength(256, ErrorMessage = "Title max 256 chars")]
        public string Name { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Sprog max 32 chars")]
        public string Language { get; set; }

        [StringLength(32, ErrorMessage = "Mellemnavn max 32 chars")]
        public string MName { get; set; }

        [Required]
        [Range(0, 3000, ErrorMessage = "Fødselsår skal være mellem 0 og 3000")]
        public int BYear { get; set; }

        [Range(0, 3000, ErrorMessage = "Dødsår skal være mellem 0 og 3000")]
        public int? DYear { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Nationalitet max 32 anslag")]
        public string Nationality { get; set; }
    }
}


/*
[Key]
        public int TitleId { get; set; }
       
        [Column(TypeName = "smallint")] //Rigeligt til årstal
        public int RYear { get; set; }

        [Column(TypeName = "smallint")]
        public int Pages { get; set; }

        [Column(TypeName = "smallint")]
        public int PublisherId { get; set; }

        [Column(TypeName = "smallint")]
        public int GenreId { get; set; }

        public List<Material> Materials { get; set; } //Giver mening at kunne se instanserne af titlerne.
    }
*/