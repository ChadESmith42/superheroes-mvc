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
    public class SourceOfPowersController : Controller
    {
        private SuperherosIncEntities db = new SuperherosIncEntities();

        // GET: SourceOfPowers
        public ActionResult Index()
        {
            return View(db.SourceOfPowers.ToList());
        }

        // GET: SourceOfPowers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SourceOfPower sourceOfPower = db.SourceOfPowers.Find(id);
            if (sourceOfPower == null)
            {
                return HttpNotFound();
            }
            return View(sourceOfPower);
        }

        // GET: SourceOfPowers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SourceOfPowers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SourceID,Description")] SourceOfPower sourceOfPower)
        {
            if (ModelState.IsValid)
            {
                db.SourceOfPowers.Add(sourceOfPower);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sourceOfPower);
        }

        // GET: SourceOfPowers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SourceOfPower sourceOfPower = db.SourceOfPowers.Find(id);
            if (sourceOfPower == null)
            {
                return HttpNotFound();
            }
            return View(sourceOfPower);
        }

        // POST: SourceOfPowers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SourceID,Description")] SourceOfPower sourceOfPower)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sourceOfPower).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sourceOfPower);
        }

        // GET: SourceOfPowers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SourceOfPower sourceOfPower = db.SourceOfPowers.Find(id);
            if (sourceOfPower == null)
            {
                return HttpNotFound();
            }
            return View(sourceOfPower);
        }

        // POST: SourceOfPowers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SourceOfPower sourceOfPower = db.SourceOfPowers.Find(id);
            db.SourceOfPowers.Remove(sourceOfPower);
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
