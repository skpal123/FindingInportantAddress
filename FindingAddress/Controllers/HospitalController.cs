using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindingAddress.DataAccessLayer;
using FindingAddress.Models;

namespace FindingAddress.Controllers
{
    public class HospitalController : Controller
    {
        //
        // GET: /Hospital/
        [HttpGet]
        public ActionResult saveHospitalType()
        {
            return View();
        }
         [HttpPost]
        public ActionResult saveHospitalType(HospitalType hospitalType)
        {
             if (ModelState.IsValid)
             {
                 HospitalGateway hospitalGateway = new HospitalGateway();
                 if (hospitalGateway.saveHospitalType(hospitalType) > 0)
                 {
                     var hospitalTypeList = hospitalGateway.GetHospitalTypes();
                     return View("showHospitaType", hospitalTypeList);
                 }
                 else
                 {
                     return ViewBag.result = "Already exits this name in the list";
                 }
             }
             else
             {
                 return View();
             }
            
        }
         public ActionResult showHospitaType()
         {
             HospitalGateway hospitalGateway = new HospitalGateway();
             var hospitalTypeList = hospitalGateway.GetHospitalTypes();
             return View(hospitalTypeList);
         }
         public ActionResult saveHospitalService()
         {
             return View();
         }
         [HttpPost]
         public ActionResult saveHospitalService(HospitalService hospitalService)
         {
             if (ModelState.IsValid)
             {
                 HospitalGateway hospitalGateway = new HospitalGateway();
                 if (hospitalGateway.saveHospitalService(hospitalService) > 0)
                 {
                     var hospitalServiceList = hospitalGateway.getHospitalServices();
                     return View("showHospitalService", hospitalServiceList);
                 }
                 else
                 {
                     return ViewBag.result = "Already exits this name in the list";
                 }
             }
             else
             {
                 return View();
             }
         }
         public ActionResult showHospitalService()
         {
             HospitalGateway hospitalGateway = new HospitalGateway();
             var hospitalServicesList = hospitalGateway.getHospitalServices();
             return View(hospitalServicesList);
         }
        public ActionResult saveHospital()
        {
            DropDownGateway dropDownGateway = new DropDownGateway();
            ViewBag.DivisionList = dropDownGateway.getDivisionDopdownList();
            ViewBag.getHospitalList = dropDownGateway.getHospitalList();
            ViewBag.getDoctorTypeDopdownList = dropDownGateway.getDoctorTypeDopdownList();
            return View();
        }
        [HttpPost]
        public ActionResult saveHospital(Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                HospitalGateway hospitalGateway = new HospitalGateway();
                if (hospitalGateway.saveHospital(hospital) > 0)
                {
                    var hospitalList = hospitalGateway.GetAllHospitals();
                    return View("showHospital",hospitalList);
                }
            }
            DropDownGateway dropDownGateway = new DropDownGateway();
            ViewBag.DivisionList = dropDownGateway.getDivisionDopdownList();
            ViewBag.cityList = dropDownGateway.getCityDopdownList();
            ViewBag.HospitalTypeDropdownList = dropDownGateway.getHospitalTypeDopdownList();
            return View();
        }
        public ActionResult showHospital()
        {
            HospitalGateway hospitalGateway = new HospitalGateway();
            var hospitalList = hospitalGateway.GetAllHospitals();
            return View(hospitalList);
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
                RedirectToAction("saveTourSpot");
            }
            return Json(new SelectList(DistrictList, "Value", "Text"));

        }
        [HttpGet]
        public ActionResult saveHospitalServiceAllocation()
        {
            DropDownGateway dropDownGateway = new DropDownGateway();
            ViewBag.divisionList = dropDownGateway.getDivisionDopdownList();
            ViewBag.ServiceList= dropDownGateway.gertServicesList();
            return View();
        }
        [HttpPost]
        public ActionResult saveHospitalServiceAllocation(HospitalServiceAllocation hospitalServiceAllocation)
         {
            if (ModelState.IsValid)
            {
                HospitalGateway hospitalGateway = new HospitalGateway();
                if (hospitalGateway.savehospitalServiceAllocation(hospitalServiceAllocation) > 0)
                {
                    var hospitalServiceAllocations = hospitalGateway.GetHospitalServiceAllocations();
                    return View("showHospitalServiceAllocation", hospitalServiceAllocations);
                }
                else
                {
                    ViewBag.result = "Already assiged this service with this Hospital";
                }
            }
            DropDownGateway dropDownGateway = new DropDownGateway();
            ViewBag.divisionList = dropDownGateway.getDivisionDopdownList();
            ViewBag.ServiceList = dropDownGateway.gertServicesList();
            return View();
        }
        public ActionResult showHospitalServiceAllocation()
        {
            HospitalGateway hospitalGateway = new HospitalGateway();
            var serviceAllocationList = hospitalGateway.GetHospitalServiceAllocations();
            return View(serviceAllocationList);
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
        public JsonResult geHospitalListByThanaId(int ThanaId)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (ThanaId != 0)
            {
                DropDownGateway dropDownGateway = new DropDownGateway();
                list = dropDownGateway.getHospitalListByThanaId(ThanaId);
            }
           
            return Json(new SelectList(list, "Value", "Text"));
        }
	}
}