using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokv1.Models.Entity;

namespace MvcStokv1.Controllers
{
    public class SatisController : Controller
    {
        MvcDBStokv1Entities db = new MvcDBStokv1Entities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Yenisatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yenisatis(TBLSATISLAR p)
        {
            db.TBLSATISLAR.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}