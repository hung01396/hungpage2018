using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hungpage2018.Models;
namespace hungpage2018.Controllers
{
    public class Test_textController : Controller
    {
        // GET: Test_text
        web1Entities2 db2 = new web1Entities2();
        public ActionResult Index()
        {
            var item = db2.test_text.Where(x => x.id == 1).FirstOrDefault();
            ViewBag.Title = "Regular Error";
            return View("Index", item);
        }
    }
}