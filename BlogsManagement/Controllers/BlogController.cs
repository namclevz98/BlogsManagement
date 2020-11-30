using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogsManagement.Models;
using BlogsManagement.DataAccess;

namespace BlogsManagement.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        [HttpGet]
        public ActionResult Index()
        {
            Blog blog = new Blog();
            DataAccessLayer objDB = new DataAccessLayer();
            blog.ShowAllBlogs = objDB.ShowallBlogs();
            return View(blog);
        }
        public ActionResult SearchBlog()
        {
            return View();
        }
        public ActionResult InsertBlog()
        {
            return View();
        }
        public ActionResult EditBlog()
        {
            return View();
        }
    }
}