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
                    return Json("请上传Excel97-2003（.xls）文件!");
                }
                else
                {
                    String filePath = HttpContext.Server.MapPath("../Uploads/data/") + DateTime.Now.ToFileTime().ToString()+".xls";
                    file.SaveAs(filePath);
                    InsertProcessor ip = new InsertProcessor(filePath);
                    Dictionary<String,String> failedRows = ip.InsertDataByFile();
                    if (failedRows.Count == 0)
                    {
                        return Json("全部插入成功");
                    }
                    else 
                    {
                        return Json(failedRows);
                    }
                }
            }
            return Json("未上传任何文件！");
        }


    }
}
