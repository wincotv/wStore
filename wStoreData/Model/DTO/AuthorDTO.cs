using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wStoreData.Model;

namespace wStoreDbContext.Models
{
    public class AuthorDTO
    {
        public AuthorDTO()
        {
        }
        public AuthorDTO(Author author)
        {
            Id = author.Id;
            AuthorName = author.FullName;
        }
        public int Id { get; set; }
        public string AuthorName { get; set; }
    }


}

namespace wStoreData.Model
{
    public partial class Author
    {
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}