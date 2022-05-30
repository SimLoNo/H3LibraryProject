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
        public int LanguageId { get; set; }

        public List<TitleMaterialsResponse> Materials { get; set; } = new List<TitleMaterialsResponse>();
        public List<TitleAuthorResponse> Author { get; set; } = new List<TitleAuthorResponse> ();
    }
    public class TitleMaterialsResponse
    {
        public int MaterialId { get; set; }
        public bool Home { get; set; }
        public int LocationId { get; set; }
        public int TitleId { get; set; }
    }

    public class TitleAuthorResponse //Modsat AuthorTitleResponse ikke liste
    {
        public int AuthorId { get; set; }
        public string LName { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public int? DYear { get; set; }
        public int BYear { get; set; }
}

}
