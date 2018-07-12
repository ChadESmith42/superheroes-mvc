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
    public class CharactersController : Controller
    {
        private SuperherosIncEntities db = new SuperherosIncEntities();

        // GET: Characters
        [Authorize]
        public ActionResult Index()
        {
            var characters = db.Characters.Include(c => c.Alignment).Include(c => c.SourceOfPower);
            return View(characters.ToList());
        }

        // GET: Characters/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: Characters/Create
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            ViewBag.AlignmentID = new SelectList(db.Alignments, "AlignmentID", "Description");
            ViewBag.SourceOfPowers = new SelectList(db.SourceOfPowers, "SourceID", "Description");
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "ID,Name,Alias,BirthDate,SourceOfPowers,Age,Sex,AlignmentID")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Characters.Add(character);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlignmentID = new SelectList(db.Alignments, "AlignmentID", "Description", character.AlignmentID);
            ViewBag.SourceOfPowers = new SelectList(db.SourceOfPowers, "SourceID", "Description", character.SourceOfPowers);
            return View(character);
        }

        // GET: Characters/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlignmentID = new SelectList(db.Alignments, "AlignmentID", "Description", character.AlignmentID);
            ViewBag.SourceOfPowers = new SelectList(db.SourceOfPowers, "SourceID", "Description", character.SourceOfPowers);
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ID,Name,Alias,BirthDate,SourceOfPowers,Age,Sex,AlignmentID")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Entry(character).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlignmentID = new SelectList(db.Alignments, "AlignmentID", "Description", character.AlignmentID);
            ViewBag.SourceOfPowers = new SelectList(db.SourceOfPowers, "SourceID", "Description", character.SourceOfPowers);
            return View(character);
        }

        // GET: Characters/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Character character = db.Characters.Find(id);
            db.Characters.Remove(character);
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
