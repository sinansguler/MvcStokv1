using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokv1.Models.Entity;

namespace MvcStokv1.Controllers
{
    public class UrunController : Controller
    {
        MvcDBStokv1Entities db = new MvcDBStokv1Entities();
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(TBLURUNLER p1)
        {
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORILER = ktg;

            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index", "Urun");

        }

        public ActionResult SIL(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index", "Urun");

        }

        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBLURUNLER.Find(id);

            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("UrunGetir", urun);
        }


        public ActionResult Guncelle(TBLURUNLER p)
        {
            var urun = db.TBLURUNLER.Find(p.Urunid);
            urun.urunadi = p.urunadi;
            urun.marka = p.marka;
            urun.STOK = p.STOK;
            urun.fiyat = p.fiyat;
            //urun.urunkategori = p.urunkategori;
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            urun.urunkategori = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }



}