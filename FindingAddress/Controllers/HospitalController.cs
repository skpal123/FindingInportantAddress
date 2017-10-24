using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindingAddress.DataAccessLayer;
namespace FindingAddress.Controllers
{
    public class HospitalController : Controller
    {
        //
        // GET: /Hospital/
        public ActionResult saveHospital()
        {
            DropDownGateway dropDownGateway = new DropDownGateway();
            ViewBag.hospitalTypes = dropDownGateway.getHospitalTypeDopdownList();
            return View();
        }
	}
}