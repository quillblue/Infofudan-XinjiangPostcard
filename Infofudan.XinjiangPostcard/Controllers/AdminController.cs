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
            return View();
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
                    String filePath = HttpContext.Server.MapPath("../uploads/data/") + file.FileName;
                    file.SaveAs(filePath);
                    InsertProcessor ip = new InsertProcessor(filePath);
                    List<int> failedRows = ip.InsertDataByFile();
                    if (failedRows.Count == 0)
                    {

                    }
                    else { }

                }
            }
            return View();
        }


    }
}
