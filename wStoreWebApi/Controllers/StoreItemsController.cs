using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using wStoreData.Model;
using wStoreDbContext.Models;
using wStoreWebApi.Models;

namespace wStoreWebApi.Controllers
{
    public class StoreItemsController : ApiController
    {
        private wStoreDb db = new wStoreDb();


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        // GET: api/StoreItems
        public IEnumerable<StoreItemDTO> GetStoreItems()
        {
            var storeItem = db.GetStoreItems();
            return storeItem;
        }

        // GET: api/StoreItems/5
        [ResponseType(typeof(StoreItemDTO))]
        public async Task<IHttpActionResult> GetStoreItem(int id)
        {
            var storeItem = await db.GetStoreItemDetail(id);
            if (storeItem == null)
            {
                return NotFound();
            }

            return Ok(storeItem);
        }

        // PUT: api/StoreItems/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStoreItem(int id, StoreItem storeItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != storeItem.Id)
            {
                return BadRequest();
            }

            db.DbContext.Entry(storeItem).State = EntityState.Modified;

            try
            {
                await db.DbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/StoreItems
        [ResponseType(typeof(StoreItem))]
        public async Task<IHttpActionResult> PostStoreItem(StoreItem storeItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DbContext.StoreItems.Add(storeItem);
            await db.DbContext.SaveChangesAsync();

            db.DbContext.Entry(storeItem).Reference(x => x.Author).Load();

            var dto = new StoreItemDTO()
            {
                Id = storeItem.Id,
                Title = storeItem.Title,
                AuthorName = new AuthorDTO(storeItem.Author).AuthorName
            };

            return CreatedAtRoute("DefaultApi", new { id = storeItem.Id }, dto);
        }

        // DELETE: api/StoreItems/5
        [ResponseType(typeof(StoreItem))]
        public async Task<IHttpActionResult> DeleteStoreItem(int id)
        {
            StoreItem storeItem = await db.DbContext.StoreItems.FindAsync(id);
            if (storeItem == null)
            {
                return NotFound();
            }

            db.DbContext.StoreItems.Remove(storeItem);
            await db.DbContext.SaveChangesAsync();

            return Ok(storeItem);
        }

        private bool StoreItemExists(int id)
        {
            return db.DbContext.StoreItems.Count(e => e.Id == id) > 0;
        }
    }
}