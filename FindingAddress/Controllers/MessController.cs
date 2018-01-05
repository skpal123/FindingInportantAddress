using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using FindingAddress.Models;
using FindingAddress.DataAccessLayer;
using Microsoft.Ajax.Utilities;

namespace FindingAddress.Controllers
{
    public class MessController : Controller
    {
        //
        // GET: /Mess/
        public ActionResult saveMess()
        {
           
            DropDownGateway dropDownGateway = new DropDownGateway();
            ViewBag.DivisonDropdownList = dropDownGateway.getDivisionDopdownList();
            ViewBag.cityDropdownlist=dropDownGateway.getCityDopdownList();
            return View();
        }
        [HttpPost]
        public ActionResult saveMess(Mess mess)
        {
            if (ModelState.IsValid)
            {
                MessGateway messGateway=new MessGateway();
                if (messGateway.saveMess(mess) > 0)
                {
                    var messList = messGateway.getAllMess();
                    return View("GetAllMess", messList);
                }
                else
                {
                    ViewBag.result = "Already has This post";
                }
            }
            DropDownGateway dropDownGateway = new DropDownGateway();
            ViewBag.DivisonDropdownList = dropDownGateway.getDivisionDopdownList();
            ViewBag.cityDropdownlist = dropDownGateway.getCityDopdownList();
            return View();
        }
        public JsonResult GetAllMess()
        {
            MessGateway messGateway = new MessGateway();
            var messList = messGateway.getAllMess();
            return Json(messList,JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult EditMess(int Id)
        {
            MessGateway messGateway = new MessGateway();
            var mess = messGateway.getMessById(Id);
            //DropDownGateway dropDownGateway = new DropDownGateway();
            ////ViewBag.DivisonDropdownList = dropDownGateway.getDivisionDopdownList();
            //ViewBag.cityDropdownlist = dropDownGateway.getCityDopdownList();
            return View(mess);
        }
        public ActionResult EditMess(Mess mess)
        {
            DropDownGateway dropDownGateway = new DropDownGateway();
            ViewBag.cityDropdownlist = dropDownGateway.getCityDopdownList();
            return View();
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
                RedirectToAction("saveMess");
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
                RedirectToAction("saveMess");
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
                RedirectToAction("saveMess");
            }
            return Json(new SelectList(list, "Value", "Text"));
        }
        public ActionResult SearchMess()
        {
            DropDownGateway dropDownGateway = new DropDownGateway();
            ViewBag.cityDropdownlist = dropDownGateway.getCityDopdownList();
            return View();
        }

        public JsonResult getAllMessByCityId(int CityId)
        {
            var MessList = new List<Mess>();
            if (CityId != 0)
            {
                MessGateway messGateway = new MessGateway();
                MessList = messGateway.getAllmessByCityId(CityId);
            }
            else
            {
                RedirectToAction("SearchMess");
            }
            return Json(MessList,JsonRequestBehavior.AllowGet);
        }
        public JsonResult getAllMessByThanaId(int ThanaId)
        {
            var MessList = new List<Mess>();
            if (ThanaId != 0)
            {
                MessGateway messGateway = new MessGateway();
                MessList = messGateway.getAllmessByThanaId(ThanaId);
            }
            else
            {
                RedirectToAction("SearchMess");
            }
            return Json(MessList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getAllMessByLocationId(int LocationId)
        {
            var MessList = new List<Mess>();
            if (LocationId != 0)
            {
                MessGateway messGateway = new MessGateway();
                //MessList = messGateway.getAllmessByLocationId(LocationId);
                MessList = messGateway.getAllMess();
            }
            else
            {
                RedirectToAction("SearchMess");
            }
            return Json(MessList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getAllMessByStartAndEndDate(DateTime? satrtDateTime,DateTime? eDateTime)
        {
            var MessList = new List<Mess>();
            MessGateway messGateway = new MessGateway();
            MessList = messGateway.getAllmessByStartAndEnddate(satrtDateTime, eDateTime);
            return Json(MessList, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult getMessDetails(int Id)
        {
            MessGateway messGateway = new MessGateway();
            var mess = messGateway.getMessById(Id);
            //DropDownGateway dropDownGateway = new DropDownGateway();
            ////ViewBag.DivisonDropdownList = dropDownGateway.getDivisionDopdownList();
            //ViewBag.cityDropdownlist = dropDownGateway.getCityDopdownList();
            return View(mess);
        }
        
	}
}