using System.Collections.Generic;

namespace H3LibraryProject.API.DTOs
{
    public class PublisherResponse
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public List<PublisherTitleResponse> Titles { get; set; } = new List<PublisherTitleResponse>();
    }
    public class PublisherTitleResponse
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
