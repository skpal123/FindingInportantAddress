using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindingAddress.Models;
using FindingAddress.DataAccessLayer;
namespace FindingAddress.Controllers
{
    public class DivisionController : Controller
    {
        //
        // GET: /Division/
        public ActionResult saveDivision()
        {
            return View();
        }
        [HttpPost]
        public ActionResult saveDivision(Division division)
        {
            if (ModelState.IsValid)
            {
                DivisionGateway divisionGateway = new DivisionGateway();
                int result = divisionGateway.saveDivision(division);
                if (result > 0)
                {
                    var divisonList=divisionGateway.getAllDivision();
                    return View("divisionList", divisonList);
                }
                else
                {
                    ViewBag.result = "Already exits";
                }
            }
            return View();
        }
        public ActionResult divisionList()
        {
            DivisionGateway divisionGateway = new DivisionGateway();
            var divisonList = divisionGateway.getAllDivision();
            return View(divisonList);
        }
        [HttpGet]
        public ActionResult Edit(int DivisonId)
        {
            var divisionGatewaw = new DivisionGateway();
            var division = divisionGatewaw.getDivisionByDivisonId(DivisonId);
            return View(division);
        }
        public ActionResult Edit(Division division)
        {
            var divisionGateway = new DivisionGateway();
            int value = divisionGateway.updateDivisionByDivisionId(division);
            var divisonList = divisionGateway.getAllDivision();
            return View("divisionList", divisonList);
        }
	}
}