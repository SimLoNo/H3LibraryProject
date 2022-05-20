﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3LibraryProject.API.Models
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }

        [Column(TypeName = "smallint")]
        public int LoanerId { get; set; }
        [Column(TypeName = "smallint")]
        public int MaterialId { get; set; }
        [Column(TypeName = "date")] //Ideel? Kan diskuteres
        public DateTime LoanDate { get; set; }
        [Column(TypeName = "date")] //Ideel? Kan diskuteres
        public DateTime ReturnDate { get; set; }

    }
}
