using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesInc.DATA.EF//.Metadata
{
    [MetadataType(typeof(CourseTypeMetadata))]
    public partial class CourseType { }

    class CourseTypeMetadata
    {
        public int TypeID { get; set; }
        [Display(Name ="Course Type")]
        public string Type { get; set; }
    }
}
