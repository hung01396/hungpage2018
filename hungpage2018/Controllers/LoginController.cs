using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using hungpage2018.Models;
namespace hungpage2018.Controllers
{
    
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(users userModel)
        {
            using (web1Entities db = new web1Entities())
            {
                var md5 = MD5.Create();
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(userModel.password));
                var strResult = BitConverter.ToString(result);
                userModel.password = strResult.Replace("-", "");
                var userDetails = db.users.Where(x => x.username == userModel.username && x.password == userModel.password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password.";
                    return View("Index", userModel);
                }
                else
                {
                    Session["userID"] = userDetails.id;
                    Session["userName"] = userDetails.username.Trim();
                    Session["userManage"] = userDetails.management;
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}