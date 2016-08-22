using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wStoreData.Model
{
    [MetadataType(typeof(StoreItemMetaData))]
    public partial class StoreItem
    {
    }

    public class StoreItemMetaData
    {
        [Required]
        [MinLength(3, ErrorMessage = ":-( ...too short...")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public System.DateTime Created { get; set; }
    }
}
