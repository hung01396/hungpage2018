using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hungpage2018.Models;
using System.Data.Entity;

namespace hungpage2018.Controllers
{
    
    public class Admin1Controller : Controller
    {
        // GET: Admin
        web1Entities1 db = new web1Entities1();
        web1Entities2 db2 = new web1Entities2();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home_IMG()
        {
            var list = db.home_img.ToList();
            return View("Home_IMG/Index", list);
        }
        public ActionResult Home_text()
        {
            var list = db2.home_text.ToList();
            return View("Home_text/Index", list);
        }
        public ActionResult Test_text()
        {
            var list = db2.test_text.ToList();
            return View("Test_text/Index", list);
        }

        public ActionResult Create(string string1, int ids)
        {
            switch (string1)
            {
                case "Home_IMG":
                    return View("Home_IMG/Create");
                default:
                    return View("Index");
            }
        }

        [HttpPost]
        public ActionResult HomeImgCreate(home_img add)
        {
            if (ModelState.IsValid)
            {
                db.home_img.Add(add);
                db.SaveChanges();
                return RedirectToAction("Home_IMG/Index", "Admin1");
            }
            else
            {
                return View("Home_IMG");
            }
        }

        public ActionResult Edit(string string1, int ids)
        {
            int? id = ids;
            if (id == null || id == 0)
            {
                return View("Index");
            }
            switch (string1)
            {
                case "Home_IMG":
                    var item = db.home_img.Where(x => x.id == id).FirstOrDefault();
                    if (item == null)
                    {
                        return View("Index");
                    }
                    else
                    {
                        return View("Home_IMG/Edit", item);
                    }
                case "Home_text":
                    var item2 = db2.home_text.Where(x => x.id == id).FirstOrDefault();
                    if (item2 == null)
                    {
                        return View("Index");
                    }
                    else
                    {
                        return View("Home_text/Edit", item2);
                    }
                case "test_text":
                    var item3 = db2.test_text.Where(x => x.id == id).FirstOrDefault();
                    if (item3 == null)
                    {
                        return View("Index");
                    }
                    else
                    {
                        return View("Test_text/Edit", item3);
                    }
                default:
                    return View("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editok(home_img change)
        {
            int? id = change.id;
            if (id == null || id == 0)
            {
                return View("Index");
            }
            if (ModelState.IsValid)
            {
                db.Entry(change).State = EntityState.Modified;
                db.SaveChanges();
                return View("Index");
            }
            return View("Index");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Editok2(home_text change)
        {
            int? id = change.id;
            if (id == null || id == 0)
            {
                return View("Index");
            }
            if (ModelState.IsValid)
            {
                db2.Entry(change).State = EntityState.Modified;
                db2.SaveChanges();
                return View("Index");
            }
            return View("Index");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Editok3(test_text change)
        {
            int? id = change.id;
            if (id == null || id == 0)
            {
                return View("Index");
            }
            if (ModelState.IsValid)
            {
                db2.Entry(change).State = EntityState.Modified;
                db2.SaveChanges();
                return View("Index");
            }
            return View("Index");

        }



        public ActionResult Delete(string string1, int ids)
        {
            int? id = ids;
            if (id == null || id == 0)
            {
                return View("Index");
            }
            switch (string1)
            {
                case "Home_IMG":
                    home_img delete = db.home_img.Find(id);
                    db.home_img.Remove(delete);
                    db.SaveChanges();
                    return View("Index");
                default:
                    return View("Index");
            }
        }

        public ActionResult NotFound404()
        {
            ViewBag.Title = "Error 404 - File not Found";
            return View("Index");
        }
    }
}