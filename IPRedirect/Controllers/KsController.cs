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
        public ActionResult Index()
        {
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
    }
}