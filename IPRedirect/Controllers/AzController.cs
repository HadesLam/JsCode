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

        /// <summary>
        /// 查询OrderNo
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 检查Url地址
        /// </summary>
        /// <returns></returns>
        public JsonResult CheckUrl()
        {
            Stream stream = Request.InputStream;

            int dataLen = Convert.ToInt32(Request.InputStream.Length);
            byte[] bytes = new byte[dataLen];
            Request.InputStream.Read(bytes, 0, dataLen);
            string requestStringData = Encoding.UTF8.GetString(bytes);

            if (!string.IsNullOrEmpty(requestStringData))
            {
                Log.Info($"【AzController/CheckUrl】REQ:{requestStringData}");
                var reqs = JsonConvert.DeserializeObject<Dictionary<string, string>>(requestStringData);
                var _url = reqs["Url"];
                var _src = $"https://www.amazon.com/gp/customer-reviews";
                if(_url.Contains(_src))
                {
                    return Json(new { success = "OK" });
                }
            }
            return Json(new { success = "NO" });
        }
    }
}