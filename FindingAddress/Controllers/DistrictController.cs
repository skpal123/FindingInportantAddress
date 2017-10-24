using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindingAddress.Models;
using FindingAddress.DataAccessLayer;
namespace FindingAddress.Controllers
{
    public class DistrictController : Controller
    {
        //
        // GET: /District/
        [HttpGet]
        public ActionResult savaDistrict()
        {
            var dropdownGateway = new DropDownGateway();
           ViewBag.divisionDropdownlist= dropdownGateway.getDivisionDopdownList();         
            return View();
        }
        [HttpPost]
        public ActionResult savaDistrict(District district)
        {
            if (ModelState.IsValid)
            {
                var districtGateway = new DistrictGateway();
               if( districtGateway.saveDistrict(district)>0)
                {
                    var districts = districtGateway.getAllDistrict();
                    return View("showDistrictList", districts);
                }
               else
               {
                   ViewBag.result = "Already have a district by this name";
               }
            }
            
            var dropdownGateway = new DropDownGateway();
            ViewBag.divisionDropdownlist = dropdownGateway.getDivisionDopdownList();
            return View();
        }
        [HttpGet]
        public ActionResult showDistrictList()
        {
           var districtGateway = new DistrictGateway();
           var distrits = districtGateway.getAllDistrict();    
            return View(distrits);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var districtGateway = new DistrictGateway();
            var district = districtGateway.getDistrictByDistrictId(id);
            var dropdownGateway = new DropDownGateway();
            ViewBag.divisionDropdownlist = dropdownGateway.getDivisionDopdownList();
            return View(district);
        }
        [HttpPost]
        public ActionResult Edit(District District)
        {

            var dropdownGateway = new DropDownGateway();
            ViewBag.divisionDropdownlist = dropdownGateway.getDivisionDopdownList();
            return View();
        }

	}
}