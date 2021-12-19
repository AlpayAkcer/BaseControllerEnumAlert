using MvcProjectSweetAlert.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MvcProjectSweetAlert.Enum.Enum;

namespace MvcProjectSweetAlert.Controllers
{
    public class HomeController : BaseController
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var list = c.Categories.ToList();
            return View(list);
        }

        public ActionResult Alert()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Category());
        }


        [HttpPost]
        public ActionResult Create(Category cat)
        {
            if (ModelState.IsValid)
            {
                c.Categories.Add(cat);
                c.SaveChanges();
                Alert("This is a success message", NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Alert("This is a error message", NotificationType.error);
            }
            return View(cat);
        }

        public ActionResult DeleteCategory(int id)
        {
            if (ModelState.IsValid)
            {
                var dto = c.Categories.Find(id);
                c.Categories.Remove(dto);
                var result = c.SaveChanges();
                Alert("Kategori Silindi", NotificationType.error);
                return RedirectToAction("Index");
            }
            else
            {
                Alert("This is a error message", NotificationType.info);
            }
            return View();
        }
    }
}