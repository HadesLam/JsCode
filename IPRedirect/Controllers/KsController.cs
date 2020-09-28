using H.Core;
using H.IService;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using H.Model;

namespace IPRedirect.Controllers
{
    public class KsController : Controller
    {
        private IKSDataService _IKSData = ServiceResposity.GetService<IKSDataService>();
        private ISettingService _ISetting = ServiceResposity.GetService<ISettingService>();

        public RedirectResult Index()
        {
            GetShowStatus();
            return Redirect("~/ks/in");
        }

        public ActionResult IN()
        {
            GetShowStatus();
            var url = Request.UrlReferrer;
            ViewBag.dsShow = false;
            if (url != null && url.AbsoluteUri.ToLower().Contains("/ds"))
            {
                ViewBag.dsShow = true;
            }
            return View();
        }

        public ActionResult RE()
        {
            GetShowStatus();
            var url = Request.UrlReferrer;
            ViewBag.dsShow = false;
            if (url != null && url.AbsoluteUri.ToLower().Contains("/ds"))
            {
                ViewBag.dsShow = true;
            }
            return View();
        }

        public ContentResult Add(string model)
        {
            if (!string.IsNullOrWhiteSpace(model))
            {
                var _ks = new KSData();
                _ks.modelCode = model;
                _IKSData.Add(_ks);
            }
            return Content("true");
        }

        public void GetShowStatus()
        {
            var isShow = _ISetting.Search("KSshow");
            if (!Convert.ToBoolean(isShow.value))
            {
                Response.Redirect("~/404.html");
            };
        }
    }
}