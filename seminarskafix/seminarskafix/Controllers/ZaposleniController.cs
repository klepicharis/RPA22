using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using seminarskafix.Data;
using seminarskafix.Models;

namespace seminarskafix.Controllers
{
    public class ZaposleniController : Controller
    {
        private seminarskafixContext db = new seminarskafixContext();

        // GET: Zaposleni
        public ActionResult Index()
        {
            var zaposlenis = db.Zaposlenis.Include(z => z.Knjiznica);
            return View(zaposlenis.ToList());
        }

        // GET: Zaposleni/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposleni zaposleni = db.Zaposlenis.Find(id);
            if (zaposleni == null)
            {
                return HttpNotFound();
            }
            return View(zaposleni);
        }

        // GET: Zaposleni/Create
        public ActionResult Create()
        {
            ViewBag.KnjiznicaId = new SelectList(db.Knjiznicas, "Id", "Ime");
            return View();
        }

        // POST: Zaposleni/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Ime,Priimek,DatumRojstva,KnjiznicaId")] Zaposleni zaposleni)
        {
            if (ModelState.IsValid)
            {
                db.Zaposlenis.Add(zaposleni);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KnjiznicaId = new SelectList(db.Knjiznicas, "Id", "Ime", zaposleni.KnjiznicaId);
            return View(zaposleni);
        }

        // GET: Zaposleni/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposleni zaposleni = db.Zaposlenis.Find(id);
            if (zaposleni == null)
            {
                return HttpNotFound();
            }
            ViewBag.KnjiznicaId = new SelectList(db.Knjiznicas, "Id", "Ime", zaposleni.KnjiznicaId);
            return View(zaposleni);
        }

        // POST: Zaposleni/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Ime,Priimek,DatumRojstva,KnjiznicaId")] Zaposleni zaposleni)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zaposleni).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KnjiznicaId = new SelectList(db.Knjiznicas, "Id", "Ime", zaposleni.KnjiznicaId);
            return View(zaposleni);
        }

        // GET: Zaposleni/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposleni zaposleni = db.Zaposlenis.Find(id);
            if (zaposleni == null)
            {
                return HttpNotFound();
            }
            return View(zaposleni);
        }

        // POST: Zaposleni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zaposleni zaposleni = db.Zaposlenis.Find(id);
            db.Zaposlenis.Remove(zaposleni);
            db.SaveChanges();
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
