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
    public class AuthorController : Controller
    {
        private ContextModel _blog = new ContextModel();

        // GET: Author
        [HttpGet]
        public ActionResult Index()
        {
            return View(_blog.Authors);
        }

        //GET: Author/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //POST: Author/Create
        [HttpPost]
        public ActionResult Create([Bind(Include ="Id, Name, Age")] Author author)
        {
            if(ModelState.IsValid)
            {
                _blog.Authors.Add(author);
                _blog.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //GET: Author/Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if(id == null)
            {

            }
            Author author = _blog.Authors.Find(id);
            if(author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        //GET: Author/Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {

            }
            Author author = _blog.Authors.Find(id);
            if(author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        //POST: Author/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Id, Name, Age")] Author author)
        {
            if(ModelState.IsValid)
            {
                _blog.Entry(author).State = EntityState.Modified;
                _blog.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        //GET: Author/Delete
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {

            }
            Author author = _blog.Authors.Find(id);
            if(author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        //POST: Author/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Author author = _blog.Authors.Find(id);
            _blog.Authors.Remove(author);
            _blog.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}