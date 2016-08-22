using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wStoreData.Model
{
    [MetadataType(typeof(EventMetaData))]
    public partial class Event
    {
    }

    public class EventMetaData
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public System.DateTimeOffset EventDate { get; set; }
        [Required]
        public int NumberOfAttendees { get; set; }
        [Required]
        public string AddresLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        [Range(1,5)]
        public int Rating { get; set; }
    }
}
