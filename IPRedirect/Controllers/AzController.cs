using H.Core;
using H.IService;
using System.Web.Mvc;

namespace IPRedirect.Controllers
{

    public class AzController : Controller
    {
        private IAZDataService _AZData = ServiceResposity.GetService<IAZDataService>();

        public ActionResult Upload()
        {
            return View();
        }

        public JsonResult GetQuery(string orderNo)
        {
            if (!string.IsNullOrWhiteSpace(orderNo))
            {
                var _data = _AZData.SearchByOrderNo(orderNo);
                if (_data != null)
                {
                    return Json(new { success = "OK", data = _data }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = "NO" }, JsonRequestBehavior.AllowGet);
        }
    }
}