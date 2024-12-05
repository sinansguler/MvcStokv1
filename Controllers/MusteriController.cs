using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokv1.Models.Entity;

namespace MvcStokv1.Controllers
{
    public class MusteriController : Controller
    {
        MvcDBStokv1Entities db = new MvcDBStokv1Entities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TBLMUSTERILER select d;
            if(!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
          
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult Yenimusteri(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            { return View("YeniMusteri"); }
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index", "Musteri");

        }

        public ActionResult Sil(int id)
        {
            var musterı = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musterı);
            db.SaveChanges();
            return RedirectToAction("Index", "Musteri");

        }

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir",mus);
        }

        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var musteri = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Musteri");
        }

    }
}
