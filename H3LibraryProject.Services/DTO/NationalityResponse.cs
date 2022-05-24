using System.Collections.Generic;

namespace H3LibraryProject.API.DTOs
{
    public class NationalityResponse
    {
        public int NationalityId { get; set; }
        public string Name { get; set; }
        public List<NationalityTitleResponse> Titles { get; set; } = new List<NationalityTitleResponse>();

    }
    public class NationalityTitleResponse
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
