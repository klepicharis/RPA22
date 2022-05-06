using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using seminarska1.Data;
using seminarska1.Models;

namespace seminarska1.Controllers
{
    public class KnjigaController : Controller
    {
        private seminarska1Context db = new seminarska1Context();

        // GET: Knjiga
        public ActionResult Index()
        {
            var knjigas = db.Knjigas.Include(k => k.Knjiznica);
            return View(knjigas.ToList());
        }

        // GET: Knjiga/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjiga knjiga = db.Knjigas.Find(id);
            if (knjiga == null)
            {
                return HttpNotFound();
            }
            return View(knjiga);
        }

        // GET: Knjiga/Create
        public ActionResult Create()
        {
            ViewBag.Knjiznicaid = new SelectList(db.Knjiznicas, "Id", "Ime");
            return View();
        }

        // POST: Knjiga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naslov,Založba,Datum,Knjiznicaid")] Knjiga knjiga)
        {
            if (ModelState.IsValid)
            {
                db.Knjigas.Add(knjiga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Knjiznicaid = new SelectList(db.Knjiznicas, "Id", "Ime", knjiga.Knjiznicaid);
            return View(knjiga);
        }

        // GET: Knjiga/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjiga knjiga = db.Knjigas.Find(id);
            if (knjiga == null)
            {
                return HttpNotFound();
            }
            ViewBag.Knjiznicaid = new SelectList(db.Knjiznicas, "Id", "Ime", knjiga.Knjiznicaid);
            return View(knjiga);
        }

        // POST: Knjiga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naslov,Založba,Datum,Knjiznicaid")] Knjiga knjiga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(knjiga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Knjiznicaid = new SelectList(db.Knjiznicas, "Id", "Ime", knjiga.Knjiznicaid);
            return View(knjiga);
        }

        // GET: Knjiga/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjiga knjiga = db.Knjigas.Find(id);
            if (knjiga == null)
            {
                return HttpNotFound();
            }
            return View(knjiga);
        }

        // POST: Knjiga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Knjiga knjiga = db.Knjigas.Find(id);
            db.Knjigas.Remove(knjiga);
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
