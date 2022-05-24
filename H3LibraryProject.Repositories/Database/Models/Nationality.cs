using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3LibraryProject.Repositories.Database
{
    public class Nationality
    {
        [Key]
        public int NationalityId { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; }
    }
}
