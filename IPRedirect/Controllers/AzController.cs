using Core;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPRedirect.Controllers
{

    public class AzController : Controller
    {
        private IAmazonData _AmazonData = ServiceResposity.GetService<IAmazonData>();

        public ActionResult Upload()
        {
            return View();
        }

        public JsonResult GetQuery(string orderNo)
        {
            if (!string.IsNullOrWhiteSpace(orderNo))
            {
                var _data = _AmazonData.SearchByOrderNo(orderNo);
                if (_data != null)
                {
                    return Json(new { success = "OK", data = _data }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = "NO" }, JsonRequestBehavior.AllowGet);
        }
    }
}