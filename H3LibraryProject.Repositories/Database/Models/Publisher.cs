using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace H3LibraryProject.API.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; }

        //Giver det mening at lave en list of publishers? Det virker meget søgt.
        //Man kunne lave en liste af de titler, der ligger under publisheren, men det er et lidt sært feature...
        //... og vi laver noget teknisk identisk andetsteds, så det forekommer redundant.
    }
}
