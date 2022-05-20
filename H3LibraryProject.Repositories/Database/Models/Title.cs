using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace H3LibraryProject.API.Models
{
    public class Title
    {
        [Key]
        public int TitleId { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; }
        [Column(TypeName = "smallint")]
        public int LanguageId { get; set; } //Bør denne her egentlig være et nyt table? 

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
}
