using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Demo.Models;
using Demo.Context;
using System.Collections;

namespace Demo.Controllers
{
    public class BlogController : Controller
    {
        private ContextModel _blog = new ContextModel();

        // GET: Blog
        public ActionResult Index()
        {
            return View(_blog.Blogs);
        }

        //GET: Blog/Create
        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }

        //POST: Blog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Name, Date, AccountId")] Blog blog)
        {
            if(ModelState.IsValid)
            {
                _blog.Blogs.Add(blog);
                _blog.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //GET: Blog/Detail 
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if(id == null)
            {

            }
            Blog blog = _blog.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        //GET: Blog/Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {

            }
            Blog blog = _blog.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        //POST: Blog/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Id, Name, AccountId, Date")] Blog blog)
        {
            if(ModelState.IsValid)
            {
                _blog.Entry(blog).State = EntityState.Modified;
                _blog.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //GET: Blog/Delete
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {

            }
            Blog blog = _blog.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        //POST: Blog/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Blog blog = _blog.Blogs.Find(id);
            _blog.Entry(blog).State = EntityState.Modified;
            _blog.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}