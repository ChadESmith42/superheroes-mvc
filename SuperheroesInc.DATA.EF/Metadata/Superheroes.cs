using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesInc.DATA.EF//.Metadata
{
    [MetadataType(typeof(CharacterMetadata))]
    public partial class Character
    {

    }

    public class CharacterMetadata
    {
        [Required]
        [Display(Name="Name")]
        [StringLength(50,ErrorMessage ="* Max 50 Characters")]
        public string Name { get; set; }
        [StringLength(100,ErrorMessage ="* Max 100 Characters")]
        public string Alias { get; set; }
        [Display(Name="Birthday")]
        [DisplayFormat(DataFormatString ="{0:d}")]
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<int> Age { get; set; }
        public string Sex { get; set; }
    }
}
