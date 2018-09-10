using FlunteNhibernate_Test0910.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlunteNhibernate_Test0910.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            SessionFactoryManager sfm = new SessionFactoryManager();

            List<Persion> list = sfm.GetAllPersion().ToList();

            ViewBag.Persion = list;
            return View();
        }
    }
}