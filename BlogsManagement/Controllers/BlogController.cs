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
            blog.ShowallBlogs = objDB.ShowAllBlogs();
            ViewBag.showCategories = objDB.ShowAllCategories();
            ViewBag.showPositions = objDB.ShowAllPositions();
            return View(blog);
        }
        [HttpGet]
        public ActionResult SearchBlog(string searchString)
        {
            List<Blog> blogs = new List<Blog>();
            DataAccessLayer objDB = new DataAccessLayer();
            ViewBag.showCategories = objDB.ShowAllCategories();
            ViewBag.showPositions = objDB.ShowAllPositions();
            if (string.IsNullOrEmpty(searchString))
            {
                blogs = objDB.ShowAllBlogs();
            }
            else
            {
                blogs = objDB.SearchBlog(searchString);
            }
            return View(blogs);
        }
        [HttpGet]
        public ActionResult InsertBlog()
        {
            DataAccessLayer objDB = new DataAccessLayer();
            ViewBag.showCategories = objDB.ShowAllCategories();
            ViewBag.showPositions = objDB.ShowAllPositions();
            return View();
        }
        [HttpPost]
        public ActionResult InsertBlog(Blog blog)
        {
            if (ModelState.IsValid)
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertBlog(blog);
                TempData["insertedSuccess"] = result;
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }
        [HttpGet]
        public ActionResult EditBlog(int Id)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            ViewBag.showCategories = objDB.ShowAllCategories();
            ViewBag.showPositions = objDB.ShowAllPositions();
            return View(objDB.ShowBlogById(Id));
        }
        [HttpPost]
        public ActionResult EditBlog(Blog blog)
        {
            if(ModelState.IsValid)
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.UpdateBlog(blog);
                TempData["updatedSuccess"] = result;
                ModelState.Clear();
                return RedirectToAction("Index");
            }    
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult DeleteBlog(int Id)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            int result = objDB.DeleteBlog(Id);
            TempData["deletedSuccess"] = result;
            ModelState.Clear();
            return RedirectToAction("Index");
        }

    }
}