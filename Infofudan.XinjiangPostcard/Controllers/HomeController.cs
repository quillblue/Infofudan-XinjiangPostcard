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

        [HttpPost]
        public ActionResult GetSenderData(int id)
        {
            PostcardRepository pr = new PostcardRepository();
            IQueryable<Place> resultSet = pr.GetPlaceListByType(1, id);
            List<MarkedCity> returnSet = new List<MarkedCity>();
            foreach (Place p in resultSet)
            {
                returnSet.Add(new MarkedCity(p));
            }
            return Json(returnSet);
        }

        [HttpPost]
        public ActionResult GetPhotoData(int id)
        {
            PostcardRepository pr = new PostcardRepository();
            IQueryable<Place> resultSet = pr.GetPlaceListByType(0, id);
            List<MarkedCity> returnSet = new List<MarkedCity>();
            foreach (Place p in resultSet)
            {
                returnSet.Add(new MarkedCity(p));
            }
            return Json(returnSet);
        }

        [HttpPost]
        public ActionResult GetGeoRecord()
        {
            PostcardRepository pr = new PostcardRepository();
            IQueryable<Place> resultSet = pr.GetPlaceList();
            String geoRecordStr = "{'拜城':[81.901235,42.045285]";
            Dictionary<String, double[]> geoRecord = new Dictionary<string, double[]>();
            foreach (Place p in resultSet)
            {
                try
                {
                    double[] lonLat = { p.Lon, p.Lat };
                    if (p.Type == 1)
                    {
                        geoRecord.Add(p.CityName, lonLat);
                        geoRecordStr += ",'" + p.CityName + "':[" + p.Lon + "," + p.Lat + "]";
                    }
                    else
                    {
                        geoRecordStr += ",'" + p.CityName+p.Detail + "':[" + p.Lon + "," + p.Lat + "]";
                        geoRecord.Add((p.CityName + p.Detail).Trim(), lonLat);
                    }
                }
                catch (Exception e){
                    Console.Write(e.Message);
                }
                
            }
            geoRecordStr += "}";
            return Json(geoRecordStr);
        }

    }
}
