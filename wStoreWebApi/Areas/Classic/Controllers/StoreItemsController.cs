using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wStoreData.Model;

namespace wStoreWebApi.Areas.Classic.Controllers
{
    public class StoreItemsController : Controller
    {
        private Entities db = new Entities();

        // GET: Classic/StoreItems
        public async Task<ActionResult> Index()
        {
            var storeItems = db.StoreItems.Include(s => s.Author);
            return View(await storeItems.ToListAsync());
        }

        // GET: Classic/StoreItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreItem storeItem = await db.StoreItems.FindAsync(id);
            if (storeItem == null)
            {
                return HttpNotFound();
            }
            return View(storeItem);
        }

        // GET: Classic/StoreItems/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "FirstName");
            return View();
        }

        // POST: Classic/StoreItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Description,Icon,Created,Changed,AuthorId")] StoreItem storeItem)
        {
            if (ModelState.IsValid)
            {
                db.StoreItems.Add(storeItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "FirstName", storeItem.AuthorId);
            return View(storeItem);
        }

        // GET: Classic/StoreItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreItem storeItem = await db.StoreItems.FindAsync(id);
            if (storeItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "FirstName", storeItem.AuthorId);
            return View(storeItem);
        }

        // POST: Classic/StoreItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Description,Icon,Created,Changed,AuthorId")] StoreItem storeItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storeItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "FirstName", storeItem.AuthorId);
            return View(storeItem);
        }

        // GET: Classic/StoreItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreItem storeItem = await db.StoreItems.FindAsync(id);
            if (storeItem == null)
            {
                return HttpNotFound();
            }
            return View(storeItem);
        }

        // POST: Classic/StoreItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StoreItem storeItem = await db.StoreItems.FindAsync(id);
            db.StoreItems.Remove(storeItem);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
