using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using seminarskafix.Data;
using seminarskafix.Models;

namespace seminarskafix.Controllers
{
    public class KnjigeController : ApiController
    {
        private seminarskafixContext db = new seminarskafixContext();

        // GET: api/Knjige
        public IQueryable<Knjiga> GetKnjigas()
        {
            return db.Knjigas;
        }

        // GET: api/Knjige/5
        [ResponseType(typeof(Knjiga))]
        public IHttpActionResult GetKnjiga(int id)
        {
            Knjiga knjiga = db.Knjigas.Find(id);
            if (knjiga == null)
            {
                return NotFound();
            }

            return Ok(knjiga);
        }

        // PUT: api/Knjige/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKnjiga(int id, Knjiga knjiga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != knjiga.Id)
            {
                return BadRequest();
            }

            db.Entry(knjiga).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnjigaExists(id))
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

        // POST: api/Knjige
        [ResponseType(typeof(Knjiga))]
        public IHttpActionResult PostKnjiga(Knjiga knjiga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Knjigas.Add(knjiga);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = knjiga.Id }, knjiga);
        }

        // DELETE: api/Knjige/5
        [ResponseType(typeof(Knjiga))]
        public IHttpActionResult DeleteKnjiga(int id)
        {
            Knjiga knjiga = db.Knjigas.Find(id);
            if (knjiga == null)
            {
                return NotFound();
            }

            db.Knjigas.Remove(knjiga);
            db.SaveChanges();

            return Ok(knjiga);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KnjigaExists(int id)
        {
            return db.Knjigas.Count(e => e.Id == id) > 0;
        }
    }
}