using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infofudan.XinjiangPostcard.Models;

namespace Infofudan.XinjiangPostcard.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData(int id)
        {
            List<Postcard> resultSet = new List<Postcard>();
            PostcardRepository pr = new PostcardRepository();
            Dictionary<string, double[]> geoRecord = new Dictionary<string, double[]>();
            return Json(resultSet, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        public ActionResult GetMarkPoint(int id)
        {
            PostcardRepository pr = new PostcardRepository();
            IQueryable<Place> resultSet = pr.GetPlaceList(id);
            return Json(resultSet, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        public ActionResult GetMarkLine(int id)
        {
            PostcardRepository pr = new PostcardRepository();
            IQueryable<Place> resultSet = pr.GetPlaceList(id);

            return View();
        }

        //[HttpPost]
        public ActionResult GetGeoRecord(int id)
        {
            PostcardRepository pr = new PostcardRepository();
            IQueryable<Place> resultSet = pr.GetPlaceList(id);
            Dictionary<String, double[]> geoRecord = new Dictionary<string, double[]>();
            foreach (Place p in resultSet)
            {
                try
                {
                    double[] lonLat = { p.Lon, p.Lat };
                    if (p.Type == 1)
                    {
                        geoRecord.Add(p.CityName, lonLat);
                    }
                    else
                    {
                        geoRecord.Add((p.CityName + p.Detail).Trim(), lonLat);
                    }
                }
                catch (Exception e){
                    Console.Write(e.Message);
                }

            }
            return Json(geoRecord, JsonRequestBehavior.AllowGet);
        }

    }
}
