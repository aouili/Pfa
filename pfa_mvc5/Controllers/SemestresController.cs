using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pfa_mvc5.DAL;
using pfa_mvc5.Models;

namespace pfa_mvc5.Controllers
{
    public class SemestresController : Controller
    {
        private PfaContext db = new PfaContext();

        // GET: Semestres
        public ActionResult Index()
        {
            return View(db.Semestre.ToList());
        }

        // GET: Semestres/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semestre semestre = db.Semestre.Find(id);
            if (semestre == null)
            {
                return HttpNotFound();
            }
            return View(semestre);
        }

        // GET: Semestres/Create
        public ActionResult Create()
        {
            ViewBag.matiere_nom = new SelectList(db.matieres, "nom", "nom");

            return View();
        }

        // POST: Semestres/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nomSemestre,matiere_nom")] Semestre semestre)
        {
            if (ModelState.IsValid)
            {
                db.Semestre.Add(semestre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(semestre);
        }

        // GET: Semestres/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semestre semestre = db.Semestre.Find(id);
            if (semestre == null)
            {
                return HttpNotFound();
            }
            return View(semestre);
        }

        // POST: Semestres/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nomSemestre,matiere_nom")] Semestre semestre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semestre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(semestre);
        }

        // GET: Semestres/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semestre semestre = db.Semestre.Find(id);
            if (semestre == null)
            {
                return HttpNotFound();
            }
            return View(semestre);
        }

        // POST: Semestres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Semestre semestre = db.Semestre.Find(id);
            db.Semestre.Remove(semestre);
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
