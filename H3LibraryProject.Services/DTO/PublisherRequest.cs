using System.ComponentModel.DataAnnotations;

namespace H3LibraryProject.API.DTOs
{
    public class PublisherRequest
    {
        [Required]
        [StringLength(32, ErrorMessage = "Name max 32 chars")]
        public string Name { get; set; }

        
    }
}
