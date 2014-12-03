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
            return Json(resultSet, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        public ActionResult GetMarkPoint(int id)
        {
            PostcardRepository pr = new PostcardRepository();
            IQueryable<Place> resultSet = pr.GetPlaceList(id);
            return Json(resultSet,JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        public ActionResult GetMarkLine(int id)
        {
            PostcardRepository pr = new PostcardRepository();
            IQueryable<Place> resultSet = pr.GetPlaceList(id);

            return View();
        }

        

    }
}
