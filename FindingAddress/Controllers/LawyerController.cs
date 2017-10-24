using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindingAddress.DataAccessLayer;
using FindingAddress.Models;
namespace FindingAddress.Controllers
{
    public class LawyerController : Controller
    {
        //
        // GET: /Lawyer/
        public ActionResult Index()
        {
            DropDownGateway dropDownGateway = new DropDownGateway();
            ViewBag.CityDropDownList = dropDownGateway.getCityDopdownList();
            ViewBag.DivisionDropdownList = dropDownGateway.getDivisionDopdownList();
            return View();
            
        }
        
	}
}