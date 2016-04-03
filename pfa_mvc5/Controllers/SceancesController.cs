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
    public class SceancesController : Controller
    {
        private PfaContext db = new PfaContext();

        // GET: Sceances
        public ActionResult Index()
        {
            var sceance = db.sceance.Include(s => s.planning).Include(s => s.professeur);
            return View(sceance.ToList());
        }

        // GET: Sceances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sceance sceance = db.sceance.Find(id);
            if (sceance == null)
            {
                return HttpNotFound();
            }
            return View(sceance);
        }

        // GET: Sceances/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.planning, "id", "nom_planning");
            ViewBag.nom_prof = new SelectList(db.Professeurs, "nom_prof", "nom_prof");
            return View();
        }

        // POST: Sceances/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_sceance,titre,start,end,background_color,border_color,url,nom_prof,id")] Sceance sceance)
        {
            if (ModelState.IsValid)
            {
                db.sceance.Add(sceance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.planning, "id", "nom_planning", sceance.id);
            ViewBag.nom_prof = new SelectList(db.Professeurs, "nom_prof", "prenom", sceance.nom_prof);
            return View(sceance);
        }

        // GET: Sceances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sceance sceance = db.sceance.Find(id);
            if (sceance == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.planning, "id", "nom_planning", sceance.id);
            ViewBag.nom_prof = new SelectList(db.Professeurs, "nom_prof", "prenom", sceance.nom_prof);
            return View(sceance);
        }

        // POST: Sceances/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_sceance,titre,start,end,background_color,border_color,url,nom_prof,id")] Sceance sceance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sceance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.planning, "id", "nom_planning", sceance.id);
            ViewBag.nom_prof = new SelectList(db.Professeurs, "nom_prof", "prenom", sceance.nom_prof);
            return View(sceance);
        }

        // GET: Sceances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sceance sceance = db.sceance.Find(id);
            if (sceance == null)
            {
                return HttpNotFound();
            }
            return View(sceance);
        }

        // POST: Sceances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sceance sceance = db.sceance.Find(id);
            db.sceance.Remove(sceance);
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
