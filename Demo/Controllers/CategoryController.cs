using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Demo.Models;
using Demo.Context;

namespace Demo.Controllers
{
    public class CategoryController : Controller
    {
        private ContextModel _blog = new ContextModel();

        // GET: Category
        public ActionResult Index()
        {
            return View(_blog.Categories);
        }

        //GET: Category/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="Id, Name")] Category category)
        {
            if(ModelState.IsValid)
            {
                _blog.Categories.Add(category);
                _blog.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //GET: Category/Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {

            }
            Category category = _blog.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        //GET: Category/Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {

            }
            Category category = _blog.Categories.Find(id);
            if(category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //POST: Category/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Id, Name")] Category category)
        {
            if(ModelState.IsValid)
            {
                _blog.Entry(category).State = EntityState.Modified;
                _blog.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //GET: Category/Delete
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {

            }

            Category category = _blog.Categories.Find(id);
            if(category == null)
            {
                return HttpNotFound();
            }
            return View(category);
           
        }

        //POST: Category/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Category category = _blog.Categories.Find(id);
            _blog.Categories.Remove(category);
            _blog.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}