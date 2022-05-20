using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace H3LibraryProject.Repositories.Database
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; }

        public List<Material> Materials { get; set; }
        //Det forekommer mig mere interessant at vide hvilke konkrete materialer, der er på det enkelte bibliotek end systemets titler.

    }
}
