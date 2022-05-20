using System.ComponentModel.DataAnnotations;

namespace H3LibraryProject.API.DTOs
{
    public class LanguageRequest
    {
        [Required]
        [StringLength(32, ErrorMessage = "Name max 32 chars")]
        public string Name { get; set; }

    }
}
