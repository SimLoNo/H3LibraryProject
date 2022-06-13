using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace H3LibraryProject.Repositories.Database
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; }
        [Column(TypeName = "int")]
        public int LeasePeriod { get; set; }

        public List<Title> Titles { get; set; }
        //giver det mening at lave en list of titles? Det gør det sikkert
    }
}