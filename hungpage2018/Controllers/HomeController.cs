using hungpage2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hungpage2018.Controllers
{
    
    public class HomeController : Controller
    {
        web1Entities1 db = new web1Entities1();
        web1Entities2 db2 = new web1Entities2();
        public ActionResult Index()
        {
            home_img home_img = new home_img();
            home_text home_text = new home_text();
            FirstModel model = new FirstModel();
            model.home_img = db.home_img.ToList();
            model.home_text = db2.home_text.ToList();
            return View("Index", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}