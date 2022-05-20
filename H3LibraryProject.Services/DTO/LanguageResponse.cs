using System.Collections.Generic;

namespace H3LibraryProject.API.DTOs
{
    public class LanguageResponse
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }

        public List<LanguageTitleResponse> Titles { get; set; } = new List<LanguageTitleResponse>();
    }

    public class LanguageTitleResponse
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
