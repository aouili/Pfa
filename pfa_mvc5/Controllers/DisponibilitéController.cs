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
    public class DisponibilitéController : Controller
    {
        private PfaContext db = new PfaContext();

        // GET: Disponibilité
        public ActionResult Index()
        {
            var disponibilités = db.Disponibilités.Include(d => d.professeurs);
            return View(disponibilités.ToList());
        }

        // GET: Disponibilité/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disponibilité disponibilité = db.Disponibilités.Find(id);
            if (disponibilité == null)
            {
                return HttpNotFound();
            }
            return View(disponibilité);
        }

        // GET: Disponibilité/Create
        public ActionResult Create()
        {
            ViewBag.nom_prof = new SelectList(db.Professeurs, "nom_prof", "nom_prof");
            return View();
        }

        // POST: Disponibilité/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,day,nom_prof,start,end")] Disponibilité disponibilité)
        {
            if (ModelState.IsValid)
            {
                db.Disponibilités.Add(disponibilité);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.nom_prof = new SelectList(db.Professeurs, "nom_prof", "prenom", disponibilité.nom_prof);
            return View(disponibilité);
        }

        // GET: Disponibilité/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disponibilité disponibilité = db.Disponibilités.Find(id);
            if (disponibilité == null)
            {
                return HttpNotFound();
            }
            ViewBag.nom_prof = new SelectList(db.Professeurs, "nom_prof", "prenom", disponibilité.nom_prof);
            return View(disponibilité);
        }

        // POST: Disponibilité/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,day,nom_prof,start,end")] Disponibilité disponibilité)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disponibilité).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nom_prof = new SelectList(db.Professeurs, "nom_prof", "prenom", disponibilité.nom_prof);
            return View(disponibilité);
        }

        // GET: Disponibilité/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disponibilité disponibilité = db.Disponibilités.Find(id);
            if (disponibilité == null)
            {
                return HttpNotFound();
            }
            return View(disponibilité);
        }

        // POST: Disponibilité/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Disponibilité disponibilité = db.Disponibilités.Find(id);
            db.Disponibilités.Remove(disponibilité);
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
