using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wStoreData.Model;

namespace wStoreDbContext.Models
{
    public class StoreItemDetailDTO
    {
        public int Id { get; set; }
      
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Changed { get; set; }
        public AuthorDTO Author { get; set; }
    }
}