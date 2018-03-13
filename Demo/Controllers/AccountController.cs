using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Demo.Context;

namespace Demo.Controllers
{
    public class AccountController : Controller
    {
        private ContextModel _blog = new ContextModel();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Create
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        //POST : Account/Register
        [HttpPost]
        public ActionResult Register([Bind(Include ="Id, UserName, PassWord")] Account account)
        {
            if(ModelState.IsValid)
            {
                _blog.Accounts.Add(account);
                _blog.SaveChanges();
                ModelState.Clear();
            }
            return View();
        }

        //GET: Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include ="UserName, PassWord")] Account account) 
        {
            if(ModelState.IsValid)
            {
                var user = _blog.Accounts.Single(u => u.UserName == account.UserName && u.PassWord == account.PassWord);
                if(user != null)
                {
                    Session["Id"] = user.Id.ToString();
                    Session["UserName"] = user.UserName.ToString();
                }
            }
            return View();
        }

        
    }
}