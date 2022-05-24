using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H3LibraryProject.Repositories.Database
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; }

        public List<Title> Titles { get; set; }
        //public ICollection<Course> courses  {get; set;} //Flemming foreviser denne her i stedet - måske generelt, men i al fald i forbindelse med mange-til-mange
    }
}
