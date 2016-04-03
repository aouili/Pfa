using pfa_mvc5.DAL;
using pfa_mvc5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace pfa_mvc5.Controllers
{
    public class authController : Controller
    {
        private PfaContext db = new PfaContext();
       
    
        //
        // GET: /auth/logIn

        public ActionResult logIn()
        {
            return View();
        }
        // Post : logIn
        [HttpPost]
        public ActionResult logIn(Auth modele )
        {
            Auth model = new Auth();
            model = db.auth.Find(modele.login);
            if (ModelState.IsValid)
            {
                if (model.type == "prof")
                {
                    FormsAuthentication.SetAuthCookie(model.login,model.rememberme);
                    return RedirectToAction("index", "profes");
                }
                else if (model.type == "chef")
                {
                    FormsAuthentication.SetAuthCookie(model.login, model.rememberme);
                    return RedirectToAction("index", "chef");
                }
                else if (model.type == "etudiant")
                {
                    FormsAuthentication.SetAuthCookie(model.login, model.rememberme);
                    return RedirectToAction("index", "etudiant");
                }
            }
            return HttpNotFound();
        }
      
        // GET: auth
        public ActionResult Index()
        {
            return View();
        }
        // GET: inscrire
        public ActionResult inscrire()
        {
            return View();
        }
    }
}