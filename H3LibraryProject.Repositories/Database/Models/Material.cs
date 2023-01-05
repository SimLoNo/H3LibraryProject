using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3LibraryProject.Repositories.Database
{
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }

        [Column(TypeName = "int")]
        public int TitleId { get; set; }

        [Column(TypeName = "int")]
        public int LocationId { get; set; }

        [Column(TypeName = "bit")] //hedder det det i SQL? Skal lige checkes. Vi må teste det ad. /RS
        public bool Home { get; set; }

        public Title Title { get; set; }

        //giver det mening at lave en list of materialer? Ja, egentlig. Men den bør vel ligge på Titles, i virkeligheden.
        //public Title { get; set; } - sådan noget i den dur? Det virker ikke så godt
    }
}
