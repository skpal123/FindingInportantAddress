using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindingAddress.DataAccessLayer;
using FindingAddress.Models;
namespace FindingAddress.Controllers
{
    public class FlatController : Controller
    {
        //
        // GET: /Flat/
        public ActionResult Index()
        {
            DropDownGateway dropDownGateway = new DropDownGateway();
            ViewBag.DistrictDropdownList = dropDownGateway.getDistrictDopdownList();
            ViewBag.CityDropdownList = dropDownGateway.getCityDopdownList();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Flat flat, int LocationId)
        {
            
            DropDownGateway dropDownGateway = new DropDownGateway();
            ViewBag.DistrictDropdownList = dropDownGateway.getDistrictDopdownList();
            ViewBag.CityDropdownList = dropDownGateway.getCityDopdownList();
            if (ModelState.IsValid)
            {
                var flatGateway = new FlatGateway();
                if (flatGateway.saveFlat(flat) > 0)
                {
                    var flatList = flatGateway.getAllFlat();
                    return View("showAllFlat", flatList);
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult showAllFlat()
        {
            var flatGateway = new FlatGateway();
            var flatList = flatGateway.getAllFlat();
            return View();
        }
        public JsonResult getThanaDropdownListByDistrictId(int DistrictId)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (DistrictId != 0)
            {
                DropDownGateway dropDownGateway = new DropDownGateway();
                list = dropDownGateway.getThanaDopdownListByDistrictId(DistrictId);
            }
            else
            {
                RedirectToAction("Index");
            }
            return Json(new SelectList(list, "Value", "Text"));
        }
        public JsonResult getLocationDropdownListByThanaId(int ThanaId)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (ThanaId != 0)
            {
                DropDownGateway dropDownGateway = new DropDownGateway();
                list = dropDownGateway.getLocationDopdownListByThanaId(ThanaId);
            }
            else
            {
                RedirectToAction("Index");
            }
            return Json(new SelectList(list, "Value", "Text"));
        }
	}
}