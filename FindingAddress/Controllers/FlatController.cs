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
            ViewBag.DivisonDropdownList = dropDownGateway.getDivisionDopdownList();
            ViewBag.CityDropdownList = dropDownGateway.getCityDopdownList();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Flat flat,string DistrictId,string LocationId, string ThanaId,string imagePath)
        {
            
            if (ModelState.IsValid)
            {
                flat.DistrictId = DistrictId;
                flat.ThanaId = ThanaId;
                flat.LocationId = LocationId;
                var flatGateway = new FlatGateway();
                if (flatGateway.saveFlat(flat) > 0)
                {
                    var flatList = flatGateway.getAllFlat();
                    return View("showAllFlat", flatList);
                }
            }
            DropDownGateway dropDownGateway = new DropDownGateway();
            ViewBag.DivisonDropdownList = dropDownGateway.getDivisionDopdownList();
            ViewBag.CityDropdownList = dropDownGateway.getCityDopdownList();
            return View();
        }
        public JsonResult showAllFlat()
        {
            var flatGateway = new FlatGateway();
            var flatList = flatGateway.getAllFlat();
            return Json(flatList,JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditFlat(int Id)
        {
            var flatGateway = new FlatGateway();
            var flat = flatGateway.getAllFlatById(Id);
            return View(flat);
        }
        public JsonResult getDistrictDropdownListByDivisionId(int DivisionId)
        {
            var DistrictList = new List<SelectListItem>();
            if (DivisionId != 0)
            {
                DropDownGateway dropDownGateway = new DropDownGateway();
                DistrictList = dropDownGateway.getDistrictDopdownListByDiisionId(DivisionId);
            }
            else
            {
                RedirectToAction("Index");
            }
            return Json(new SelectList(DistrictList, "Value", "Text"));

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
        [HttpGet]
        public ActionResult SearchFlat()
        {
            DropDownGateway dropDownGateway=new DropDownGateway();
            ViewBag.cityDropdownlist = dropDownGateway.getCityDopdownList();
            return View();
        }
        public JsonResult SearchAllFlat()
        {
            FlatGateway flatGateway=new FlatGateway();
            var  flatList = flatGateway.getAllFlat();
            return Json(flatList, JsonRequestBehavior.AllowGet);
        }
	}
}