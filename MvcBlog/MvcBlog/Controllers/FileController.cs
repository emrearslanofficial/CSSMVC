using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem { Text = x.AuthorName, Value = x.AuthorId.ToString() }).ToList();
            ViewBag.values2 = values2;

            return View();
        }

        [HttpPost]
        public ActionResult AddNewBlog(Blog b, HttpPostedFileBase Image)
        {
            Context c = new Context();
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Image.FileName);
                string uzanti = Path.Combine(Server.MapPath("~/Image/"), dosyaadi);
                Image.SaveAs(dosyaadi);
                b.BlogImage = "/Image/" + dosyaadi;
            }
            bm.BlogAddBL(b);
            c.SaveChanges();
            return RedirectToAction("AdminBlogList2");
        }
    }
}