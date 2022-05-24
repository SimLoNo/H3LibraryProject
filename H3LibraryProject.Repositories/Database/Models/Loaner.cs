using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3LibraryProject.Repositories.Database
{
    public class Loaner
    {
        [Key]
        public int LoanerId { get; set; }

        [Column(TypeName = "int")]
        public int LoanerTypeId { get; set; } //Bør være connected til et eksternt table.

        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; } //Måske username? Det er i al fald det, vi kommer til at bruge det til.

        [Column(TypeName = "nvarchar(32)")]
        public string Password { get; set; }


        public LoanerType TypeOfLoaner { get; set; }
        public List<Loan> Loans { get; set; }


        //Her kunne man åbenlyst have rigtig meget mere info. F.eks. har man i den virkelige verden CPR-nr, adresse, fulde navn, og typisk tlf.nr. og email.
    }
}
