﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3LibraryProject.API.Models
{
    public class Loaner
    {
        [Key]
        public int LoanerId { get; set; }

        [Column(TypeName = "smallint")]
        public int LoanerType { get; set; } //Bør være connected til et eksternt table.
        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; } //Måske username? Det er i al fald det, vi kommer til at bruge det til.


        //Her kunne man åbenlyst have rigtig meget mere info. F.eks. har man i den virkelige verden CPR-nr, adresse, fulde navn, og typisk tlf.nr. og email.
    }
}