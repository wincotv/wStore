using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using wStoreData.Model;

namespace wStoreDbContext.Models
{
    public class wStoreDb : IDisposable
    {

        public wStoreDb()
        {
            dbContext = new Entities();
        }

        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
                dbContext = null;
            }
       }

        private Entities dbContext;
        public Entities DbContext
        {
            get
            {
                return dbContext;
            }
        }

        public IEnumerable<StoreItemDTO> GetStoreItems()
        {
            var result =
                from c in DbContext.StoreItems.ToList()
                select new StoreItemDTO()
                {
                    Id = c.Id,
                    Title = c.Title,
                    AuthorName = new AuthorDTO(c.Author).AuthorName
                };

            return result;
        }

        public Task<StoreItemDetailDTO> GetStoreItemDetail(int id)
        {
            // DbContext.Configuration.ProxyCreationEnabled = false;

            var result = DbContext.StoreItems.Where(c => c.Id == id).Include(c => c.Author).ToList()
                .Select(c =>
                    new StoreItemDetailDTO()
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Description = c.Description,
                        Author = new AuthorDTO(c.Author),
                        Created = c.Created
                    }).SingleOrDefault();

            return Task.Run(() => result);
        }

        public IEnumerable<AuthorDTO> GetAuthors()
        {
            var result = DbContext.Authors.ToList()
                .Select(
                    c => new AuthorDTO(c)
                    );

            return result;
        }

    }
}
