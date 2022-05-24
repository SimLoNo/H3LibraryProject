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
        [Range(0, 150000, ErrorMessage = "Pages must be between 0 and 150000")]
        public int Pages { get; set; }
        
        [Required]
        [Range(0, 3000, ErrorMessage = "Releaseyear must be between 0 and 3000")]
        public int RYear { get; set; }

        [Required]
        [Range(1, 1000000000, ErrorMessage = "Genre-ID must be above 0")]
        public int GenreId { get; set; }

        [Required]
        [Range(1, 1000000000, ErrorMessage = "Forfatter-ID must be above 0")]
        public int AuthorId { get; set; } //Så er der plads til en millard forfattere - burde være nok
        [Required]
        [Range(1, 1000000000, ErrorMessage = "Nationality-ID must be above 0")]
        public int NationalityId { get; set; }
    }
}
