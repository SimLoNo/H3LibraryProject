using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H3LibraryProject.API.Models
{
    public class LoanerType
    {
        [Key]
        public int LoanerTypeId { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; }
    }
}
