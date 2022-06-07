using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using H3LibraryProject.Repositories.Database.Models;

namespace H3LibraryProject.Repositories.Database
{
    public class Title
    {
        [Key]
        public int TitleId { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; }

        [Column(TypeName = "int")]
        public int LanguageId { get; set; }

        [Column(TypeName = "smallint")] //Rigeligt til årstal
        public int RYear { get; set; }

        [Column(TypeName = "smallint")]
        public int Pages { get; set; }

        [Column(TypeName = "int")]
        public int PublisherId { get; set; }
        [Column(TypeName = "int")]
        public int AuthorId { get; set; }

        [Column(TypeName = "int")]
        public int GenreId { get; set; }

        public List<Material> Materials { get; set; } = new List<Material>(); //Giver mening at kunne se instanserne af titlerne.
        public Genre Genre { get; set; }

        public List<Author> Authors { get; set; } = new List<Author>();
    }
}
