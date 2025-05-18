using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Adapters;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class HomeController : Controller
    {

        ToDoEntitiesConnectionStringDB db=new ToDoEntitiesConnectionStringDB();
        [Authorize]

        public ActionResult Listele()
        {
            ToDoEntitiesConnectionStringDB db = new ToDoEntitiesConnectionStringDB();
            //ViewBag.isler = db.islers;
            ViewBag.sayfa = "acikIsler";
            ViewBag.isler = db.islers.Where(o=> o.durum=="1").ToList();

            return View();
        }

        //buradan bi listele action açıp tamamlnamş işlerin olduğu sayfayı yapicaz
        
        [Authorize]
        public ActionResult KapaliIsListele()
        {
            ToDoEntitiesConnectionStringDB db = new ToDoEntitiesConnectionStringDB();
            //ViewBag.isler = db.islers;
            ViewBag.sayfa = "kapaliIsler";
            ViewBag.isler = db.islers.Where(o => o.durum == "0").ToList();

            return View();
        }

        [Authorize]
        public ActionResult Kaydet(string txtIsinAdi)
        {
            string isinAdi = txtIsinAdi.ToString();
            DateTime olusturuldugu_tarih = DateTime.Now;
            string durum = "1"; //yani devam eden bitmemiş işler 1 tamamlanmış işler 0 şeklinde ifade edeceğiz

            ToDoEntitiesConnectionStringDB db = new ToDoEntitiesConnectionStringDB();

            var yeniIs = new isler
            {
                is_adi = isinAdi,
                durum = durum,
                olusturuldugu_tarih = olusturuldugu_tarih
            };
            db.islers.Add(yeniIs);
            db.SaveChanges();


            return RedirectToAction("Listele");
        }
        
        [Authorize]
        public ActionResult Sil (int id)
        {
         ToDoEntitiesConnectionStringDB db = new ToDoEntitiesConnectionStringDB ();
            isler silinecek =db.islers.FirstOrDefault(x => x.id == id);
            db.islers.Remove(silinecek);
            db.SaveChanges ();
            return RedirectToAction("Listele");



        }

        [Authorize]
        public ActionResult IsKapat(int id)
        {
            ToDoEntitiesConnectionStringDB db = new ToDoEntitiesConnectionStringDB();
            isler kapatilacakIs = db.islers.FirstOrDefault(x => x.id == id);
            kapatilacakIs.tamamlandigi_tarih = DateTime.Now;
            kapatilacakIs.durum = "0";
            db.SaveChanges();
            return RedirectToAction("Listele");



        }

        [Authorize]
        public ActionResult IsiYenidenAc(int id)
        {
            ToDoEntitiesConnectionStringDB db = new ToDoEntitiesConnectionStringDB();
            isler acilacakIs = db.islers.FirstOrDefault(x=>x.id == id);

            acilacakIs.tamamlandigi_tarih = null;
            acilacakIs.durum = "1";
            db.SaveChanges();
            return RedirectToAction("KapaliIsListele");



        }



        [Authorize]
        public ActionResult Duzenle(int id, string txtIsinAdi)
        {
            ToDoEntitiesConnectionStringDB db = new ToDoEntitiesConnectionStringDB();
            isler duzenlenecekIs = db.islers.FirstOrDefault(x => x.id == id);
            
            duzenlenecekIs.is_adi = txtIsinAdi;

            db.SaveChanges();
            return RedirectToAction("Listele");



        }

        public  ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Login");
        }











    }
}