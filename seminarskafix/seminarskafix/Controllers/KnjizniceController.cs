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
    public class KnjizniceController : ApiController
    {
        private seminarskafixContext db = new seminarskafixContext();

        // GET: api/Knjiznice
        public IQueryable<Knjiznica> GetKnjiznicas()
        {
            return db.Knjiznicas;
        }

        // GET: api/Knjiznice/5
        [ResponseType(typeof(Knjiznica))]
        public IHttpActionResult GetKnjiznica(int id)
        {
            Knjiznica knjiznica = db.Knjiznicas.Find(id);
            if (knjiznica == null)
            {
                return NotFound();
            }

            return Ok(knjiznica);
        }

        // PUT: api/Knjiznice/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKnjiznica(int id, Knjiznica knjiznica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != knjiznica.Id)
            {
                return BadRequest();
            }

            db.Entry(knjiznica).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnjiznicaExists(id))
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

        // POST: api/Knjiznice
        [ResponseType(typeof(Knjiznica))]
        public IHttpActionResult PostKnjiznica(Knjiznica knjiznica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Knjiznicas.Add(knjiznica);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = knjiznica.Id }, knjiznica);
        }

        // DELETE: api/Knjiznice/5
        [ResponseType(typeof(Knjiznica))]
        public IHttpActionResult DeleteKnjiznica(int id)
        {
            Knjiznica knjiznica = db.Knjiznicas.Find(id);
            if (knjiznica == null)
            {
                return NotFound();
            }

            db.Knjiznicas.Remove(knjiznica);
            db.SaveChanges();

            return Ok(knjiznica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KnjiznicaExists(int id)
        {
            return db.Knjiznicas.Count(e => e.Id == id) > 0;
        }
    }
}