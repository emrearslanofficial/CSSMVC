using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace MvcBlog.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        BlogManager bm = new BlogManager();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult BlogList(int page = 1)
        {
            var bloglist = bm.GetAll().ToPagedList(page, 6);

            return PartialView(bloglist);
        }

        [AllowAnonymous]
        public PartialViewResult FeaturedPost()
        {
            //1.Post
            var posttitle1 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1)
                .Select(y => y.BlogTitle).FirstOrDefault();
            var postimage1 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1)
                .Select(y => y.BlogImage).FirstOrDefault();
            var blogdate1 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1)
                .Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid1 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1)
               .Select(y => y.BlogId).FirstOrDefault();

            ViewBag.posttitle1 = posttitle1;
            ViewBag.postimage1 = postimage1;
            ViewBag.blogdate1 = blogdate1;
            ViewBag.blogpostid1 = blogpostid1;

            //2.Post
            var posttitle2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4)
                .Select(y => y.BlogTitle).FirstOrDefault();
            var postimage2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4)
                .Select(y => y.BlogImage).FirstOrDefault();
            var blogdate2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4)
                .Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4)
                .Select(y => y.BlogId).FirstOrDefault();

            ViewBag.posttitle2 = posttitle2;
            ViewBag.postimage2 = postimage2;
            ViewBag.blogdate2 = blogdate2;
            ViewBag.blogpostid2 = blogpostid2;

            //3.Post
            var posttitle3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 6)
                .Select(y => y.BlogTitle).FirstOrDefault();
            var postimage3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 6)
                .Select(y => y.BlogImage).FirstOrDefault();
            var blogdate3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 6)
                .Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 6)
                .Select(y => y.BlogId).FirstOrDefault();

            ViewBag.posttitle3 = posttitle3;
            ViewBag.postimage3 = postimage3;
            ViewBag.blogdate3 = blogdate3;
            ViewBag.blogpostid3 = blogpostid3;

            //4.Post
            var posttitle4 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3)
                .Select(y => y.BlogTitle).FirstOrDefault();
            var postimage4 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3)
                .Select(y => y.BlogImage).FirstOrDefault();
            var blogdate4 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3)
                .Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid4 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3)
                .Select(y => y.BlogId).FirstOrDefault();

            ViewBag.posttitle4 = posttitle4;
            ViewBag.postimage4 = postimage4;
            ViewBag.blogdate4 = blogdate4;
            ViewBag.blogpostid4 = blogpostid4;


            //5.Post
            var posttitle5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 7)
                .Select(y => y.BlogTitle).FirstOrDefault();
            var postimage5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 7)
                .Select(y => y.BlogImage).FirstOrDefault();
            var blogdate5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 7)
                .Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 7)
                .Select(y => y.BlogId).FirstOrDefault();

            ViewBag.posttitle5 = posttitle5;
            ViewBag.postimage5 = postimage5;
            ViewBag.blogdate5 = blogdate5;
            ViewBag.blogpostid5 = blogpostid5;


            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult OtherFeaturedPost()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }

        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }

        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var BlogListByCategory = bm.GetBlogByCategory(id);
            var CategoryName = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.CategoryName = CategoryName;
            var CategoryDesc = bm.GetBlogByCategory(id).Select(z => z.Category.CategoryDescription).FirstOrDefault();
            ViewBag.CategoryDesc = CategoryDesc;
            return View(BlogListByCategory);
        }

        public ActionResult AdminBlogList()
        {
            var bloglist = bm.GetAll();
            return View(bloglist);
        }

        public ActionResult AdminBlogList2()
        {
            var bloglist = bm.GetAll();
            return View(bloglist);
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
        public ActionResult AddNewBlog(Blog b)
        {
            Context c = new Context();
            string fileName = Guid.NewGuid().ToString();
            var ext = Path.GetExtension(Request.Files[0].FileName);
            b.BlogImage= @"\Image\" + fileName + ext;
            c.Blogs.Add(b);
            c.SaveChanges();
            return RedirectToAction("AdminBlogList2");
        }

        public ActionResult DeleteBlog(int id)
        {
            bm.DeleteBlogBL(id);
            return RedirectToAction("AdminBlogList2");
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog blog = bm.FindBlog(id);
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem { Text = x.AuthorName, Value = x.AuthorId.ToString() }).ToList();
            ViewBag.values2 = values2;
            return View(blog);
        }

        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            bm.UpdateBlog(p);
            return RedirectToAction("AdminBlogList2");
        }

        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager cm = new CommentManager();
            var commentlist = cm.CommentByBlog(id);
            return PartialView(commentlist);
        }

        public ActionResult AuthorBlogList(int id)
        {

            var blogs = bm.GetBlogByAuthor(id);
            return View(blogs);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin", "Login");
        }
    }
}