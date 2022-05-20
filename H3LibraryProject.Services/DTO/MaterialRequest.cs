﻿using System.ComponentModel.DataAnnotations;

namespace H3LibraryProject.API.DTOs
{
    public class MaterialRequest
    {
        [Required]
        [StringLength(32, ErrorMessage = "Fornavn max 32 anslag")]
        public string LName { get; set; }

        [Required]
        public bool Home { get; set; }

        [Required]
        [Range(1, 1000000000, ErrorMessage = "Location-ID must be above 0")]
        public int LocationId { get; set; }

        [Required]
        [Range(1, 1000000000, ErrorMessage = "Title-ID must be above 0")]
        public int TitleId { get; set; }

    }
}
