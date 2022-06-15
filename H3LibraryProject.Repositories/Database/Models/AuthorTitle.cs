using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3LibraryProject.Repositories.Database.Models
{
    public class AuthorTitle
    {
        [Key]
        public int AuthorTitleId { get; set; }

        [Column(TypeName = "int")]
        public int AuthorId { get; set; }


        [Column(TypeName = "int")]
        public int TitleId { get; set; }

        public Author Author { get; private set; }

        public Title Title { get; private set; }
    }
}
