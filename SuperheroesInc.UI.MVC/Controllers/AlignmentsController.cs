using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuperheroesInc.DATA.EF;

namespace SuperheroesInc.UI.MVC.Controllers
{
    public class AlignmentsController : Controller
    {
        private SuperherosIncEntities db = new SuperherosIncEntities();

        // GET: Alignments
        public ActionResult Index()
        {
            return View(db.Alignments.ToList());
        }

        // GET: Alignments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alignment alignment = db.Alignments.Find(id);
            if (alignment == null)
            {
                return HttpNotFound();
            }
            return View(alignment);
        }

        // GET: Alignments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlignmentID,Description")] Alignment alignment)
        {
            if (ModelState.IsValid)
            {
                db.Alignments.Add(alignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alignment);
        }

        // GET: Alignments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alignment alignment = db.Alignments.Find(id);
            if (alignment == null)
            {
                return HttpNotFound();
            }
            return View(alignment);
        }

        // POST: Alignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlignmentID,Description")] Alignment alignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alignment);
        }

        // GET: Alignments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alignment alignment = db.Alignments.Find(id);
            if (alignment == null)
            {
                return HttpNotFound();
            }
            return View(alignment);
        }

        // POST: Alignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alignment alignment = db.Alignments.Find(id);
            db.Alignments.Remove(alignment);
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
