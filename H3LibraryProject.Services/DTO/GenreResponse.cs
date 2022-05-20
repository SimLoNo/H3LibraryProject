using System.Collections.Generic;

namespace H3LibraryProject.API.DTOs
{
    public class GenreResponse
    {
        public int GenreId { get; set; }
        public string Name { get; set; }       
        public int LeasePeriod { get; set; }

        public List<GenreTitleResponse> Titles { get; set; } = new List<GenreTitleResponse>();
        //Sådan har den virket i mit program tidligere.

    }

    public class GenreTitleResponse
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

