using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindingAddress.DataAccessLayer;
using FindingAddress.Models;
namespace FindingAddress.Controllers
{
    public class TravelController : Controller
    {
        //
        // GET: /Travel/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult travel()
        {
            TravelGateway travelGateWay=new TravelGateway();
            List<TravelCategory> travelCategoryList = travelGateWay.getAllTravelCategory();
            return View(travelCategoryList);
        }
	}
}