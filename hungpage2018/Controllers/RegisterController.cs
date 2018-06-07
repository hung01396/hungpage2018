using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hungpage2018.Models;
using System.Security.Cryptography;
using System.Text;
namespace hungpage2018.Controllers
{
   
    public class RegisterController : Controller
    {
        // GET: Register
        web1Entities db = new web1Entities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(users adduser)
        {

            if (ModelState.IsValid)
            {
                var userDetails = db.users.Where(x => x.username == adduser.username).FirstOrDefault();
                if (userDetails == null)
                {
                    if (adduser.password == adduser.confirmpassword)
                    {
                        var md5 = MD5.Create();
                        var result = md5.ComputeHash(Encoding.ASCII.GetBytes(adduser.password));
                        var strResult = BitConverter.ToString(result);
                        adduser.username = adduser.username.Trim();
                        adduser.password = strResult.Replace("-", "");
                        db.users.Add(adduser);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        adduser.LoginErrorMessage = "Inconsistent password";
                        return View("Index", adduser);
                    }
                }
                else
                {
                    adduser.LoginErrorMessage = "This user is already registered";
                    return View("Index", adduser);
                }



            }

            return View("Index", adduser);
        }
    }
}