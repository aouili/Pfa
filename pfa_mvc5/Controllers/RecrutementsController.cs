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
using System.IO;

namespace pfa_mvc5.Controllers
{
    public class RecrutementsController : Controller
    {
        private PfaContext db = new PfaContext();

        // GET: Recrutements
        public ActionResult Index()
        {
            return View(db.Recrutement.ToList());
        }

        // GET: Recrutements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recrutement recrutement = db.Recrutement.Find(id);
            if (recrutement == null)
            {
                return HttpNotFound();
            }
            return View(recrutement);
        }

        // GET: Recrutements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recrutements/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Create(Recrutement recrut, HttpPostedFileBase file)
        {
            string filename = "";
            HttpPostedFileBase f1 = file;
            if (ModelState.IsValid)
            {
                try
                {
                    filename = Path.GetFileName(f1.FileName);

                    f1.SaveAs(Server.MapPath("~/uploads/" + filename));
                    string filepathtosave = filename;
                    recrut.cv_path = filepathtosave;
                    recrut.etat = "en attente";
                    db.Recrutement.Add(recrut);
                    db.SaveChanges();
                    return RedirectToAction("Index","Home");

                }
                catch
                {
                    ViewBag.Message = "Error while uploading the files.";
                }
            }
            return View();
        }

        // GET: Recrutements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recrutement recrutement = db.Recrutement.Find(id);
            if (recrutement == null)
            {
                return HttpNotFound();
            }
            return View(recrutement);
        }

        // POST: Recrutements/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,cv_path,etat")] Recrutement recrutement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recrutement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recrutement);
        }

        // GET: Recrutements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recrutement recrutement = db.Recrutement.Find(id);
            if (recrutement == null)
            {
                return HttpNotFound();
            }
            return View(recrutement);
        }

        // POST: Recrutements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recrutement recrutement = db.Recrutement.Find(id);
            db.Recrutement.Remove(recrutement);
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
