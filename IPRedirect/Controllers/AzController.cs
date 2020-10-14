using H.Core;
using H.IService;
using H.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace IPRedirect.Controllers
{

    public class AzController : Controller
    {
        private IAZDataService _AZData = ServiceResposity.GetService<IAZDataService>();
        private IMCDataService _MCData = ServiceResposity.GetService<IMCDataService>();

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
                var _orderId = reqs["order_no"];
                if (Regex.IsMatch(_orderId, @"^\d{3}-\d{7}-\d{7}$"))
                {
                    var _data = _AZData.SearchByOrderNo(_orderId);
                    var _mcdata = new MCData();
                    _mcdata.buyer_email = reqs["order_email"];
                    if (_data != null)
                    {
                        _mcdata.buyer_orderno = _data.refrence_no_platform;
                        _mcdata.IsQueryOK = 1;
                        _MCData.Add(_mcdata);

                        string _link = "";
                        if (_data.platform_user_name.Contains("US")) _link = "https://www.amazon.com/review/review-your-purchases/listing";
                        if (_data.platform_user_name.Contains("UK")) _link = "https://www.amazon.co.uk/review/review-your-purchases/listing";
                        if (_data.platform_user_name.Contains("CA")) _link = "https://www.amazon.ca/review/review-your-purchases/listing";
                        if (_data.platform_user_name.Contains("DE")) _link = "https://www.amazon.de/review/review-your-purchases/listing";
                        return Json(new { success = "OK", message = "Got it. Thanks!", link = _link, data = _data });
                    }
                    else
                    {
                        _mcdata.buyer_orderno = reqs["order_no"];
                        _mcdata.IsQueryOK = 0;
                        _MCData.Add(_mcdata);
                    }
                    return Json(new { success = "OK", message = "Got it. Thanks!" });
                }
                else
                {
                    return Json(new { success = "NO", message = "Invalid order number!" });
                }
            }
            return Json(new { success = "NO", message = "Invalid request!" });
        }

        /// <summary>
        /// 检查Url地址
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCheckUrl()
        {
            Stream stream = Request.InputStream;

            int dataLen = Convert.ToInt32(Request.InputStream.Length);
            byte[] bytes = new byte[dataLen];
            Request.InputStream.Read(bytes, 0, dataLen);
            string requestStringData = Encoding.UTF8.GetString(bytes);

            if (!string.IsNullOrEmpty(requestStringData))
            {
                Log.Info($"【AzController/GetCheckUrl】REQ:{requestStringData}");
                var reqs = JsonConvert.DeserializeObject<Dictionary<string, string>>(requestStringData);
                var _order_customer_reviews = reqs["order_customer_reviews"];
                var _order_link = reqs["order_link"];
                var _obj_order_customer_reviews = new Uri(_order_customer_reviews);
                var _obj_order_link = new Uri(_order_link);
                var _target = $"/gp/customer-reviews";
                if (_order_customer_reviews.Contains(_target) && _obj_order_customer_reviews.Host.Equals(_obj_order_link.Host))
                {
                    var _mcdata = new MCData();
                    _mcdata.buyer_orderno = reqs["order_no"];
                    _mcdata.buyer_email = reqs["order_email"];
                    _mcdata.buyer_customer_reviews = _order_customer_reviews;
                    _MCData.Update(_mcdata);
                    return Json(new { success = "OK", result = true });
                }
            }
            return Json(new { success = "NO", result = false });
        }

    }
}