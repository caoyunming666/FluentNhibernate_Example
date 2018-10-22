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
        readonly SessionFactoryManager sfm = new SessionFactoryManager();
        // GET: Home
        public ActionResult Index()
        {
            List<Persion> list = sfm.GetAllPersion().ToList();

            ViewBag.Persion = list;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Persion persion)
        {
            if (persion == null)
            {
                throw new NullReferenceException("Persion");
            }

            if (string.IsNullOrWhiteSpace(persion.Name))
            {
                throw new NullReferenceException("Persion.Name");
            }

            sfm.SavePersion(persion);

            return Redirect("/Home/Index");
        }


        public ActionResult Edit(int id)
        {
            Persion model = sfm.GetPersionById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Persion persion)
        {
            if (persion == null)
            {
                throw new NullReferenceException("Persion");
            }

            Persion model = sfm.GetPersionById(persion.Id);
            if (model == null)
            {
                throw new NullReferenceException("Persion.Id");
            }

            model.Name = persion.Name;
            model.Age = persion.Age;

            sfm.UpdatePersion(model);

            return Redirect("/Home/Index");
        }
    }
}