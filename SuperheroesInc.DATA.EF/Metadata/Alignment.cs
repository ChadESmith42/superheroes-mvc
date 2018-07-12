using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesInc.DATA.EF//.Metadata
{
    [MetadataType(typeof(AlignmentMetadata))]
    public partial class Alignment { }

    class AlignmentMetadata
    {
        public int AlignmentID { get; set; }
        [Required]
        [Display(Name ="Alignment")]
        public string Description { get; set; }
    }
}
