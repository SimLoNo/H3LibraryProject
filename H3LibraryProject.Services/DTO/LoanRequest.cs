using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H3LibraryProject.API.DTOs
{
    public class LoanRequest
    {        
        [Required]
        [Range(0, 30000000, ErrorMessage = "LoanderId must be between 0 og 300000000")]
        public int LoanerId { get; set; }

        [Range(0, 3000000000, ErrorMessage = "Materialnr must be between 0 and 3 billion")]
        public int MaterialId { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Nationalitet max 32 anslag")]

        [Column(TypeName = "date")] //Ideel? Kan diskuteres
        public DateTime LoanDate { get; set; }
        [Column(TypeName = "date")] //Ideel? Kan diskuteres
        public DateTime ReturnDate { get; set; }
    }
}
