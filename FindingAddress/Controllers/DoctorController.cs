using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindingAddress.DataAccessLayer;
using FindingAddress.Models;

namespace FindingAddress.Controllers
{
    public class DoctorController : Controller
    {
        //
        // GET: /Doctor/
        [HttpGet]
        public ActionResult Index()
        {
            DropDownGateway dropDownGateway = new DropDownGateway();
            ViewBag.DivisionList = dropDownGateway.getDivisionDopdownList();
            ViewBag.DoctorTypeDopdownList = dropDownGateway.getDoctorTypeDopdownList();
            ViewBag.HospitalDropdownList = dropDownGateway.getHospitalList();
            ViewBag.cityList = dropDownGateway.getCityDopdownList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(Doctor doctor)
        {
            DropDownGateway dropDownGateway = new DropDownGateway();
            if (ModelState.IsValid)
            {
                DoctorGateway doctorGateway = new DoctorGateway();
                if (doctorGateway.saveDoctor(doctor) > 0)
                {
                    var doctorsList = doctorGateway.GetAllDoctors();
                    return View("ShowAllDoctor", doctorsList);
                }
            }
            ViewBag.DivisionList = dropDownGateway.getDivisionDopdownList();
            ViewBag.DoctorTypeDopdownList = dropDownGateway.getDoctorTypeDopdownList();
            ViewBag.HospitalDropdownList = dropDownGateway.getHospitalList();
            ViewBag.cityList = dropDownGateway.getCityDopdownList();
            return View();
        }

        public ActionResult ShowAllDoctor(Doctor doctor)
        {
            DoctorGateway doctorGateway = new DoctorGateway();
            var doctorsList = doctorGateway.GetAllDoctors();
            return View(doctorsList);
        }

        public ActionResult ShowDoctorDetailsById(int id)
        {
            DoctorGateway doctorGateway = new DoctorGateway();
            var doctor = doctorGateway.GetDoctorsDetailsByid(id);
            return View(doctor);
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

        public JsonResult SearchDoctor(int DistrictId)
        {
            DoctorGateway doctorGateway=new DoctorGateway();
            var doctorList = doctorGateway.GetAllDoctors();
            return Json(new SelectList(doctorList, "Value", "Text"));
        }
    }
}