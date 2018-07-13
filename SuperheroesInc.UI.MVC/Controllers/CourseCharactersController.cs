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
    public class CourseCharactersController : Controller
    {
        private SuperherosIncEntities db = new SuperherosIncEntities();

        // GET: CourseCharacters
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            var courseCharacters = db.CourseCharacters.Include(c => c.Character).Include(c => c.Cours);
            return View(courseCharacters.ToList());
        }

        // GET: CourseCharacters/Details/5
        [Authorize(Roles ="Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseCharacter courseCharacter = db.CourseCharacters.Find(id);
            if (courseCharacter == null)
            {
                return HttpNotFound();
            }
            return View(courseCharacter);
        }

        // GET: CourseCharacters/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.CharacterID = new SelectList(db.Characters, "ID", "Name");
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Name");
            return View();
        }

        // POST: CourseCharacters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "CourseID,CharacterID,ID")] CourseCharacter courseCharacter)
        {
            if (ModelState.IsValid)
            {
                db.CourseCharacters.Add(courseCharacter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CharacterID = new SelectList(db.Characters, "ID", "Name", courseCharacter.CharacterID);
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Name", courseCharacter.CourseID);
            return View(courseCharacter);
        }

        // GET: CourseCharacters/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseCharacter courseCharacter = db.CourseCharacters.Find(id);
            if (courseCharacter == null)
            {
                return HttpNotFound();
            }
            ViewBag.CharacterID = new SelectList(db.Characters, "ID", "Name", courseCharacter.CharacterID);
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Name", courseCharacter.CourseID);
            return View(courseCharacter);
        }

        // POST: CourseCharacters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "CourseID,CharacterID,ID")] CourseCharacter courseCharacter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseCharacter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CharacterID = new SelectList(db.Characters, "ID", "Name", courseCharacter.CharacterID);
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Name", courseCharacter.CourseID);
            return View(courseCharacter);
        }

        // GET: CourseCharacters/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseCharacter courseCharacter = db.CourseCharacters.Find(id);
            if (courseCharacter == null)
            {
                return HttpNotFound();
            }
            return View(courseCharacter);
        }

        // POST: CourseCharacters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseCharacter courseCharacter = db.CourseCharacters.Find(id);
            db.CourseCharacters.Remove(courseCharacter);
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
