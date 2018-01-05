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
        public ActionResult saveLawyer()
        {
            DropDownGateway dropDownGateway = new DropDownGateway();
            ViewBag.CityDropDownList = dropDownGateway.getCityDopdownList();
            ViewBag.DivisionDropdownList = dropDownGateway.getDivisionDopdownList();
            ViewBag.LawyerTypeList = dropDownGateway.getLawerTypeDopdownList();
            ViewBag.CourstList = dropDownGateway.GetCourtsList();
            return View();
            
        }
        [HttpPost]
        public ActionResult saveLawyer(Lawyer lawyer)
        {
            if (ModelState.IsValid)
            {
                LawyerGateway lawyerGateway=new LawyerGateway();
                if (lawyerGateway.saveLawyer(lawyer) > 0)
                {
                    List<Lawyer> lawyers=new List<Lawyer>();
                    lawyers = lawyerGateway.GetAllLayers();
                    return View("showAllLayer", lawyers);
                }
            }
            DropDownGateway dropDownGateway = new DropDownGateway();
            ViewBag.CityDropDownList = dropDownGateway.getCityDopdownList();
            ViewBag.DivisionDropdownList = dropDownGateway.getDivisionDopdownList();
            ViewBag.LawyerTypeList = dropDownGateway.getLawerTypeDopdownList();
            ViewBag.CourstList = dropDownGateway.GetCourtsList();
            return View();

        }
        [HttpGet]
        public ActionResult showAllLayer()
        {
            LawyerGateway lawyerGateway = new LawyerGateway();
            List<Lawyer> lawyers = new List<Lawyer>();
            lawyers = lawyerGateway.GetAllLayers();
            return View(lawyers);
        }
        public ActionResult showLayerDtails(int id)
        {
            LawyerGateway lawyerGateway = new LawyerGateway();
          var  lawyer = lawyerGateway.GetLawyerDetails(id);
          return View(lawyer);
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
                RedirectToAction("");
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

            return Json(new SelectList(list, "Value", "Text"));
        }
    }
}