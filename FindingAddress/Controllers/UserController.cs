using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindingAddress.Models;
using FindingAddress.DataAccessLayer;
namespace FindingAddress.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            return View();
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            if ((string)Session["Username"] != null && (string)Session["Username"] != null)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(LogIn login )
        {
            UserGateway userGateway = new UserGateway();
            Session["Username"] = login.UserName;
            Session["Password"] = login.Password;
            Session["RoleName"] = userGateway.findRollNameByUsername((string)Session["Username"]);
            if ((string)Session["Username"] != null && (string)Session["Username"] != null)
            {
                
                int count = userGateway.verifyUserAccount((string)Session["Username"], (string)Session["Password"]);
                if (count > 0)
                {
                   return RedirectToAction("AdminPage","User");
                }
                else
                {
                    ViewBag.result = "not log in";
                }
            }
            else
            {
               return RedirectToAction("LogIn", "User");
            }
            return View();
        }
        [HttpGet]
        public ActionResult AdminPage()
        {
            if ((string)Session["Username"] != null && (string)Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "User");
            }
        }
        
        [HttpGet]
        [OutputCache(NoStore=true,Duration=0,VaryByParam="*")]
        public ActionResult logout()
        {
            Session.Clear();
            Session.Abandon();
            return View("LogIn");
        }
	}
}