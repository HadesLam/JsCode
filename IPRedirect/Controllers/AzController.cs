using H.Core;
using H.IService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace IPRedirect.Controllers
{

    public class AzController : Controller
    {
        private IAZDataService _AZData = ServiceResposity.GetService<IAZDataService>();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetQuery()
        {
            Stream stream = Request.InputStream;

            int dataLen = Convert.ToInt32(Request.InputStream.Length);
            byte[] bytes = new byte[dataLen];
            Request.InputStream.Read(bytes, 0, dataLen);
            string requestStringData = Encoding.UTF8.GetString(bytes);

            if (!string.IsNullOrEmpty(requestStringData))
            {
                Log.Info($"【AzController/GetQuery】REQ:{requestStringData}");
                var reqs = JsonConvert.DeserializeObject<Dictionary<string, string>>(requestStringData);
                var _data = _AZData.SearchByOrderNo(reqs["OrderNo"]);
                if (_data != null)
                {
                    return Json(new { success = "OK", data = _data });
                }
            }
            return Json(new { success = "NO" });
        }
    }
}