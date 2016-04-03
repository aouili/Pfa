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
    public class planningsController : Controller
    {
        private PfaContext db = new PfaContext();

        // GET: plannings
        public ActionResult Index()
        {
            var planning = db.planning.Include(p => p.classe).Include(p => p.semestre);
            return View(planning.ToList());
        }

        // GET: plannings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planning planning = db.planning.Find(id);
            if (planning == null)
            {
                return HttpNotFound();
            }
            return View(planning);
        }

        // GET: plannings/Create
        public ActionResult Create()
        {
            ViewBag.nom_classe = new SelectList(db.classes, "nom_classe", "nom_classe");
            ViewBag.nomSemestre = new SelectList(db.Semestre, "nomSemestre", "nomSemestre");
            return View();
        }

        // POST: plannings/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom_planning,nom_classe,nomSemestre,etat")] planning planning)
        {
            if (ModelState.IsValid)
            {
                planning.etat = "non_complet";
                db.planning.Add(planning);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.nom_classe = new SelectList(db.classes, "nom_classe", "groupe", planning.nom_classe);
            ViewBag.nomSemestre = new SelectList(db.Semestre, "nomSemestre", "matiere_nom", planning.nomSemestre);
            return View(planning);
        }

        // GET: plannings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planning planning = db.planning.Find(id);
            if (planning == null)
            {
                return HttpNotFound();
            }
            ViewBag.nom_classe = new SelectList(db.classes, "nom_classe", "groupe", planning.nom_classe);
            ViewBag.nomSemestre = new SelectList(db.Semestre, "nomSemestre", "matiere_nom", planning.nomSemestre);
            return View(planning);
        }

        // POST: plannings/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom_planning,nom_classe,nomSemestre,etat")] planning planning)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planning).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nom_classe = new SelectList(db.classes, "nom_classe", "groupe", planning.nom_classe);
            ViewBag.nomSemestre = new SelectList(db.Semestre, "nomSemestre", "matiere_nom", planning.nomSemestre);
            return View(planning);
        }

        // GET: plannings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planning planning = db.planning.Find(id);
            if (planning == null)
            {
                return HttpNotFound();
            }
            return View(planning);
        }

        // POST: plannings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            planning planning = db.planning.Find(id);
            db.planning.Remove(planning);
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
