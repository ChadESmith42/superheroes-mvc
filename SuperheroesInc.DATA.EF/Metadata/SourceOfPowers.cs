using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesInc.DATA.EF//.Metadata
{
    [MetadataType(typeof(SourceOfPowerMetadata))]
    public partial class SourceOfPower
    {

    }

    class SourceOfPowerMetadata
    {
        public int SourceID { get; set; }
        [Display(Name ="Source of Powers")]
        public string Description { get; set; }
    }
}
