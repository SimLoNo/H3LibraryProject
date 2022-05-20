using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3LibraryProject.API.DTOs
{
    public class AuthorResponse
    {

        public int AuthorId { get; set; }
        public string LName { get; set; }
        public string FName { get; set; }
        public string MName { get; set; } //Funktionelt implicit nullable, da en string bare kan være ""
        public int BYear { get; set; }
        public int? DYear { get; set; }
        public string Nationality { get; set; }

        public List<AuthorTitleResponse> Books { get; set; } = new List<AuthorTitleResponse>();
        //Sådan har den virket i mit program tidligere.

    }

    public class AuthorTitleResponse
    {
        public int TitleId { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public int RYear { get; set; }
        public int Pages { get; set; }
        public int PublisherId { get; set; }
        public int GenreId { get; set; }
    }
}
