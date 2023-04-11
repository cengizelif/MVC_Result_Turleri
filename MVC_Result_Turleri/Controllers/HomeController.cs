using MVC_Result_Turleri.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC_Result_Turleri.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public RedirectResult Index2()
        {
            // return RedirectToAction("Index");
            // return Redirect("/Home/Index");
            return Redirect("https://google.com");
        }

        public JsonResult Index3()
        {
            Urun u = new Urun();
            u.Id = 1;
            u.Adi = "bilgisayar";
            u.Fiyati = 20000;
            u.Aciklama = "Yeni ürün";
            return Json(u, JsonRequestBehavior.AllowGet);
        }

        static List<string> veriler = new List<string>();

        public ActionResult AnaSayfa(string ad)
        {
            ViewBag.liste = veriler;
            return View();
        }

        [HttpPost]
        public ActionResult AnaSayfa(string ad, string soyad)
        {
            veriler.Add(ad + " " + soyad);

            return new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
            {
                action = "AnaSayfa",
                controller = "Home",
                kod = Guid.NewGuid().ToString()
            }));

        }

        public ActionResult Dosyalar()
        {
            return View();
        }

        public FileResult PDFDosyaGoster()
        {
            string dosya = Server.MapPath("~/Dosyalar/ch01.pdf");
            return new FilePathResult(dosya, "application/pdf");
        }

        public FileStreamResult MetinDosyasiIndir()
        {
            MemoryStream memo = new MemoryStream();
            string metin = "Bu bir deneme yazısıdır";
            byte[] bytes = Encoding.UTF8.GetBytes(metin);
            memo.Write(bytes, 0, bytes.Length);
            memo.Position = 0;

            FileStreamResult sonuc = new FileStreamResult(memo, "text/plain");
            sonuc.FileDownloadName = "deneme.txt";

            return sonuc;
        }

        public PartialViewResult KategoriGetir()
        {
            return PartialView("_KategorilerPartialPage");
        }

        public PartialViewResult KategoriGetir2()
        {
            List<string> kategoriler = new List<string>()
             {
                "Teknoloji","Giyim","Gıda","Temizlik"
             };
            return PartialView("_PartialPageKategoriler2", kategoriler);
        }

        public JavaScriptResult Mesaj()
        {
            string mesaj = "alert('Merhaba Dünya')";
            return JavaScript(mesaj);
        }

        public JavaScriptResult ButtonMesaj()
        {
            string js = "function button_click() { alert('Merhaba Dünya');}";
            return JavaScript(js);
        }

    }
}