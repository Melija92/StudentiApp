using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EF;

namespace StudentApp.Controllers
{
    public class FakultetsController : Controller
    {
        private StudentAppEntities db = new StudentAppEntities();

        // GET: Fakultets
        public ActionResult Index()
        {
            return View(db.Fakultet.ToList());
        }

        // GET: Fakultets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fakultet fakultet = db.Fakultet.Find(id);
            if (fakultet == null)
            {
                return HttpNotFound();
            }
            return View(fakultet);
        }

        // GET: Fakultets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fakultets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FakultetId,Naziv,OIB,Adresa")] Fakultet fakultet)
        {
            if (ModelState.IsValid)
            {
                db.Fakultet.Add(fakultet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fakultet);
        }

        // GET: Fakultets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fakultet fakultet = db.Fakultet.Find(id);
            if (fakultet == null)
            {
                return HttpNotFound();
            }
            return View(fakultet);
        }

        // POST: Fakultets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FakultetId,Naziv,OIB,Adresa")] Fakultet fakultet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fakultet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fakultet);
        }

        // GET: Fakultets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fakultet fakultet = db.Fakultet.Find(id);
            if (fakultet == null)
            {
                return HttpNotFound();
            }
            return View(fakultet);
        }

        // POST: Fakultets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fakultet fakultet = db.Fakultet.Find(id);
            db.Fakultet.Remove(fakultet);
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
