using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infofudan.XinjiangPostcard.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View("AddMore");
        }

        [HttpPost]
        public ActionResult Upload()
        {
            HttpPostedFileBase file = Request.Files["file"];
            if (file != null)
            {
                if (!file.FileName.EndsWith("xls"))
                {

                }
                else
                {
                    String filePath = HttpContext.Server.MapPath("../Uploads/data/") + DateTime.Now.ToFileTime().ToString()+".xls";
                    file.SaveAs(filePath);
                    InsertProcessor ip = new InsertProcessor(filePath);
                    List<String> failedRows = ip.InsertDataByFile();
                    if (failedRows.Count == 0)
                    {
                        return Json("All Success");
                    }
                    else 
                    {
                        
                    }

                }
            }
            return Json("Failed Somewhere",JsonRequestBehavior.AllowGet);
        }


    }
}
