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
    public class ZaposleneController : ApiController
    {
        private seminarskafixContext db = new seminarskafixContext();

        // GET: api/Zaposlene
        public IQueryable<Zaposleni> GetZaposlenis()
        {
            return db.Zaposlenis;
        }

        // GET: api/Zaposlene/5
        [ResponseType(typeof(Zaposleni))]
        public IHttpActionResult GetZaposleni(int id)
        {
            Zaposleni zaposleni = db.Zaposlenis.Find(id);
            if (zaposleni == null)
            {
                return NotFound();
            }

            return Ok(zaposleni);
        }

        // PUT: api/Zaposlene/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutZaposleni(int id, Zaposleni zaposleni)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zaposleni.id)
            {
                return BadRequest();
            }

            db.Entry(zaposleni).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZaposleniExists(id))
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

        // POST: api/Zaposlene
        [ResponseType(typeof(Zaposleni))]
        public IHttpActionResult PostZaposleni(Zaposleni zaposleni)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zaposlenis.Add(zaposleni);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = zaposleni.id }, zaposleni);
        }

        // DELETE: api/Zaposlene/5
        [ResponseType(typeof(Zaposleni))]
        public IHttpActionResult DeleteZaposleni(int id)
        {
            Zaposleni zaposleni = db.Zaposlenis.Find(id);
            if (zaposleni == null)
            {
                return NotFound();
            }

            db.Zaposlenis.Remove(zaposleni);
            db.SaveChanges();

            return Ok(zaposleni);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZaposleniExists(int id)
        {
            return db.Zaposlenis.Count(e => e.id == id) > 0;
        }
    }
}