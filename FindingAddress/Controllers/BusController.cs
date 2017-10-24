using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindingAddress.Models;
using FindingAddress.DataAccessLayer;
namespace FindingAddress.Controllers
{
    public class BusController : Controller
    {
        //
        // GET: /Bus/
        [HttpGet]
        public ActionResult saveBus()
        {
            return View();
        }
        [HttpPost]
        public ActionResult saveBus(BusCompany busCompany)
        {
            if (ModelState.IsValid)
            {
                var busCompanyGateway = new BUsCompanyGateway();
                int result = busCompanyGateway.saveBusCompany(busCompany);
                if (result > 0)
                {
                    var busCompanyList = busCompanyGateway.getAllBusCompany();
                    return View("busCompanyDetails", busCompanyList);
                }
                else
                {
                    ViewBag.result = "This bus company already exits";
                }
            }
            return View();
        }
        public ActionResult busCompanyDetails()
        {
            var busCompanyGateway = new BUsCompanyGateway();
            var busCompanyList = busCompanyGateway.getAllBusCompany();
            return View(busCompanyList);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var busCompanyGateway = new BUsCompanyGateway();
            var busCompany = busCompanyGateway.getBusCompanyById(Id);
            return View(busCompany);
        }
        [HttpPost]
        public ActionResult Edit(BusCompany buscompany)
        {
            var busCompanyGateway = new BUsCompanyGateway();
            int result = busCompanyGateway.updateBusCompanyById(buscompany);
            if (result != -1)
            {
                var busCompany = busCompanyGateway.getAllBusCompany();
                return View("busCompanyDetails", busCompany);
            }
            else
            {
                ViewBag.result = "Updataing faild";
                return View();
            }
           
        }
        [HttpGet]
        public ActionResult saveBusStatiopn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult saveBusStatiopn(BusStation busStation)
        {
            if (ModelState.IsValid)
            {
                var busStationGateway = new BusStationGateway();
                if (busStationGateway.saveBusStation(busStation) > 0)
                {
                    var busStationList = busStationGateway.getAllBusstation();
                    return View("showBusStationList", busStationList);
                }
            }
            return View();
        }
        public ActionResult showBusStationList()
        {
            return View();
        }
        public ActionResult EditBusStation( int Id)
        {
            var busStationGateway = new BusStationGateway();
            var busStation=busStationGateway.getBusstationById(Id);
            return View(busStation);
        }
        [HttpGet]
        public ActionResult assignBusStation()
        {
            var dropdownGateway = new DropDownGateway();
            ViewBag.buscompanyDropdownList = dropdownGateway.getBusCompanyDopdownList();
            ViewBag.busStationDropdownList = dropdownGateway.gertBusStationDropdownList();      
            return View();
        }
        [HttpPost]
        public ActionResult assignBusStation(BusAssignStation busAssignStation)
        {
            var dropdownGateway = new DropDownGateway();
            ViewBag.buscompanyDropdownList = dropdownGateway.getBusCompanyDopdownList();
            ViewBag.busStationDropdownList = dropdownGateway.gertBusStationDropdownList();
            if (ModelState.IsValid)
            {
                 var busStationGateway = new BusStationGateway();
                if(busStationGateway.saveBusAssignStation(busAssignStation)>0)
                {
                    var busAssignStationLst = busStationGateway.getBusAssignStation();
                    return View("ShowassignBusStation", busAssignStationLst);
                }
                else
                {
                    ViewBag.result = "Failed";
                    return View();
                }
               
            }
            else
            {
                return View();
            }
            
        }
        public ActionResult ShowassignBusStation()
        {
            var busStationGateway=new BusStationGateway();
            var busAssignStationLst = busStationGateway.getBusAssignStation();
            return View(busAssignStationLst);
        }
	}
}