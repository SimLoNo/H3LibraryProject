using System.Collections.Generic;

namespace H3LibraryProject.API.DTOs
{
    public class TitleResponse
    {
        public int TitleId { get; set; }        
        public string Name { get; set; }
        public int Pages { get; set; }
        public int RYear { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }        
        public int NationalityId { get; set; }

        public List<TitleMaterialsResponse> Materials { get; set; } = new List<TitleMaterialsResponse>();
    }
    public class TitleMaterialsResponse
    {
        public int MaterialId { get; set; }
        public bool Home { get; set; }
        public int LocationId { get; set; }
        public int TitleId { get; set; }
    }

}
