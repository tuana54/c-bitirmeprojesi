using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        ToDoEntitiesConnectionStringDB db = new ToDoEntitiesConnectionStringDB();
        public ActionResult Login (string kullanici_adi, String sifre)
        {
            var kullanici =db.kullanicilars.FirstOrDefault(x=>x.kullanici_adi == kullanici_adi && x.sifre == sifre );

            if ( kullanici != null )
            {
                FormsAuthentication.SetAuthCookie( kullanici_adi,false );
                return RedirectToAction("Listele","Home");
            }
            else { return RedirectToAction("Index"); }

        }
    }
}