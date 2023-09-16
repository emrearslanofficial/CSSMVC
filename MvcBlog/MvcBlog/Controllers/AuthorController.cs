﻿using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager blogmanager = new BlogManager();
        AuthorManager authormanager = new AuthorManager();

        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authordetail = blogmanager.GetBlogByID(id);
            return PartialView(authordetail);
        }

        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogauthorid = blogmanager.GetAll().Where(x => x.BlogId == id)
                .Select(y => y.AuthorId).FirstOrDefault();
            var authorblogs = blogmanager.GetBlogByAuthor(blogauthorid);
            return PartialView(authorblogs);
        }

        public ActionResult AuthorList()
        {
            var authorlists = authormanager.GetAll();
            return View(authorlists);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
            authormanager.AddAuthorBL(p);
            return RedirectToAction("AuthorList");
        }

        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author = authormanager.FindAuthor(id);
            ViewBag.autid = author;
            return View(author);
        }

        [HttpPost]
        public ActionResult AuthorEdit(Author p)
        {
            authormanager.EditAuthor(p);
            return RedirectToAction("AuthorList");
        }

    }
}