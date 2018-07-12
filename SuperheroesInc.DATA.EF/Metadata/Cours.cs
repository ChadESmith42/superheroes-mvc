using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesInc.DATA.EF//.Metadata
{
    [MetadataType(typeof(CoursMetadata))]
    public partial class Cours { }

    class CoursMetadata
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Course Name")]
        [StringLength(100, ErrorMessage = "* Max 100 Characters")]
        public string Name { get; set; }
        [Display(Name = "Course Description")]
        [StringLength(500, ErrorMessage = "* Max 500 Characters")]
        public string Description { get; set; }
        [Required]
        public int TypeID { get; set; }
        [DisplayFormat(DataFormatString = "{0:f}")]
        public Nullable<System.DateTime> Date { get; set; }
        [Display(Name = "Course Location")]
        [StringLength(140, ErrorMessage = "* Max 140 Characters")]
        public string Location { get; set; }
    }
}
