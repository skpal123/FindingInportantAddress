using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindingAddress.Models;
using FindingAddress.DataAccessLayer;
namespace FindingAddress.Controllers
{
    public class TourSpotImageController : Controller
    {
        //
        // GET: /TourSpotImage/
        public ActionResult saveTourSoptImage()
        {
            DropDownGateway dropDownGateway=new DropDownGateway();
            ViewBag.TourSpotList = dropDownGateway.GeTourSpotDropDownList();
            return View();
        }
        [HttpPost]
        public ActionResult saveTourSoptImage(TourSpotImage tourSpotImage, HttpPostedFileBase ImagePath)
        {
            if (ImagePath != null)
            {
                string picPath = System.IO.Path.GetFileName(ImagePath.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Images"), picPath);
                tourSpotImage.ImagePath = "~/Images/" + picPath;
                ImagePath.SaveAs(path);
                TourSpotImageGateway tourGateway = new TourSpotImageGateway();
                tourGateway.saveTourSpotImage(tourSpotImage);
            }
            DropDownGateway dropDownGateway = new DropDownGateway();
            ViewBag.TourSpotList = dropDownGateway.GeTourSpotDropDownList();
            return View();
        }
        [HttpGet]
        public ActionResult saveTourSpot()
        {
            return View();
        }
        [HttpPost]
        public ActionResult saveTourSpot(TourSpot tourSpot)
        {
            return View();
        }
	}
}