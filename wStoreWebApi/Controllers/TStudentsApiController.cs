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

namespace wStoreWebApi.Controllers
{
    public class TStudentsApiController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/TStudents
        public IQueryable<TStudent> GetTStudents()
        {
            return db.TStudents;
        }

        // GET: api/TStudents/5
        [ResponseType(typeof(TStudent))]
        public async Task<IHttpActionResult> GetTStudent(int id)
        {
            TStudent tStudent = await db.TStudents.FindAsync(id);
            if (tStudent == null)
            {
                return NotFound();
            }

            return Ok(tStudent);
        }

        // PUT: api/TStudents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTStudent(int id, TStudent tStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tStudent.StudentID)
            {
                return BadRequest();
            }

            db.Entry(tStudent).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TStudentExists(id))
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

        // POST: api/TStudentsAPI
        [ResponseType(typeof(TStudent))]
        [HttpPost]
        public async Task<IHttpActionResult> PostTStudent(TStudent tStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TStudents.Add(tStudent);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tStudent.StudentID }, tStudent);
        }

        // DELETE: api/TStudentsAPI/5
        [ResponseType(typeof(TStudent))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteTStudent(TStudent student)
        {
            TStudent tStudent = await db.TStudents.FindAsync(student.StudentID);
            if (tStudent == null)
            {
                return NotFound();
            }

            db.TStudents.Remove(tStudent);
            await db.SaveChangesAsync();

            return Ok(tStudent);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TStudentExists(int id)
        {
            return db.TStudents.Count(e => e.StudentID == id) > 0;
        }
    }
}