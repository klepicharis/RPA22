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
    public class KnjiznicaController : Controller
    {
        private seminarskafixContext db = new seminarskafixContext();

        // GET: Knjiznica
        public ActionResult Index()
        {
            return View(db.Knjiznicas.ToList());
        }

        // GET: Knjiznica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjiznica knjiznica = db.Knjiznicas.Find(id);
            if (knjiznica == null)
            {
                return HttpNotFound();
            }
            return View(knjiznica);
        }

        // GET: Knjiznica/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Knjiznica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ime,Kraj")] Knjiznica knjiznica)
        {
            if (ModelState.IsValid)
            {
                db.Knjiznicas.Add(knjiznica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(knjiznica);
        }

        // GET: Knjiznica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjiznica knjiznica = db.Knjiznicas.Find(id);
            if (knjiznica == null)
            {
                return HttpNotFound();
            }
            return View(knjiznica);
        }

        // POST: Knjiznica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ime,Kraj")] Knjiznica knjiznica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(knjiznica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(knjiznica);
        }

        // GET: Knjiznica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjiznica knjiznica = db.Knjiznicas.Find(id);
            if (knjiznica == null)
            {
                return HttpNotFound();
            }
            return View(knjiznica);
        }

        // POST: Knjiznica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Knjiznica knjiznica = db.Knjiznicas.Find(id);
            db.Knjiznicas.Remove(knjiznica);
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
