﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3LibraryProject.Repositories.Database.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string LName { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        [Required]
        public string FName { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string MName { get; set; }

        [Column(TypeName = "int")] //Rigeligt til årstal
        public int BYear { get; set; }

        [Column(TypeName = "int")]
        public int? DYear { get; set; } //Nullable

        [Column(TypeName = "int")]
        public int NationalityId { get; set; }

        public List<Title> Titles { get; set; }
        public Nationality Nationality { get; set; }
        //public ICollection<Course> courses  {get; set;} //Flemming foreviser denne her i stedet - måske generelt, men i al fald i forbindelse med mange-til-mange
    }
}
