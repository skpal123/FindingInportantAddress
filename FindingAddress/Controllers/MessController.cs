using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindingAddress.Models;
using FindingAddress.DataAccessLayer;
namespace FindingAddress.Controllers
{
    public class MessController : Controller
    {
        //
        // GET: /Mess/
        public ActionResult saveMess()
        {
            DropDownGateway dropDownGateway = new DropDownGateway();
            ViewBag.cityDropdownlist=dropDownGateway.getCityDopdownList();
            return View();
        }
        [HttpPost]
        public ActionResult saveMess(Mess mess)
        {
            DropDownGateway dropDownGateway = new DropDownGateway();
            ViewBag.cityDropdownlist = dropDownGateway.getCityDopdownList();
            return View();
        }
	}
}