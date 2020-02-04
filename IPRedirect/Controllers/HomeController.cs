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
    public class HomeController : Controller
    {
        private IVisitorService _IVisitor = ServiceResposity.GetService<IVisitorService>();
        public object Index()
        {
            try
            {
                //var _data = IPGetCity();
                var _data = IPGetCityCode();
                if (_data != null)
                {
                    var _visitor = new Visitor();
                    _visitor.IP = GetIP();
                    _visitor.Country = _data["country"].ToString();
                    _visitor.ISP = _data["isp"].ToString();
                    _visitor.JsonStr = JsonConvert.SerializeObject(_data);
                    _IVisitor.Add(_visitor);

                    //switch (_data["country_id"].ToString().ToUpper())
                    switch (_data["countryCode"].ToString().ToUpper())
                    {
                        case "US":
                            return Redirect("https://infantryusa.com/");
                        default:
                            return Redirect("https://www.infantrywatchco.com");
                    }
                }
                else
                {
                    throw new Exception($"IPGetCity is null");
                }
            }
            catch (Exception ex)
            {
                return Json(new { Success = "NO", IP = GetIP(), sIP = IP, MSG = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        static Dictionary<string, object> IPGetCityCode()
        {
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            Byte[] pageData = MyWebClient.DownloadData($"http://ip-api.com/json/{GetIP()}"); //从指定网站下载数据
            string pageHtml = Encoding.UTF8.GetString(pageData);
            if (!string.IsNullOrWhiteSpace(pageHtml))
            {
                JObject dic = (JObject)JsonConvert.DeserializeObject(pageHtml);
                if (dic["status"].ToString() == "success")
                {
                    return dic.ToObject<Dictionary<string, object>>();
                }
            }
            return null;
        }

        static Dictionary<string, object> IPGetCity()
        {
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            Byte[] pageData = MyWebClient.DownloadData($"http://ip.taobao.com/service/getIpInfo.php?ip={GetIP()}"); //从指定网站下载数据
            string pageHtml = Encoding.UTF8.GetString(pageData);
            if (!string.IsNullOrWhiteSpace(pageHtml))
            {
                JObject dic = (JObject)JsonConvert.DeserializeObject(pageHtml);
                if (dic["code"].ToString() == "0")
                {
                    return dic["data"].ToObject<Dictionary<string, object>>();
                }
            }
            return null;
        }


        /// <summary>
        /// 获取IP
        /// </summary>
        /// <returns></returns>
        private static string GetIP()
        {
            string ip = string.Empty;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]))
                ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(',')[0]);
            if (string.IsNullOrEmpty(ip))
                ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            if (string.IsNullOrEmpty(ip))
                ip = System.Web.HttpContext.Current.Request.UserHostAddress;
            return ip;

        }

        public static Int64 toDenaryIp(string ip)
        {
            Int64 _Int64 = 0;
            string _ip = ip;
            if (_ip.LastIndexOf(".") > -1)
            {
                string[] _iparray = _ip.Split('.');

                _Int64 = Int64.Parse(_iparray.GetValue(0).ToString()) * 256 * 256 * 256 + Int64.Parse(_iparray.GetValue(1).ToString()) * 256 * 256 + Int64.Parse(_iparray.GetValue(2).ToString()) * 256 + Int64.Parse(_iparray.GetValue(3).ToString()) - 1;
            }
            return _Int64;
        }

        /// <summary>
        /// /ip十进制
        /// </summary>
        public static Int64 DenaryIp
        {
            get
            {
                Int64 _Int64 = 0;

                string _ip = IP;
                if (_ip.LastIndexOf(".") > -1)
                {
                    string[] _iparray = _ip.Split('.');

                    _Int64 = Int64.Parse(_iparray.GetValue(0).ToString()) * 256 * 256 * 256 + Int64.Parse(_iparray.GetValue(1).ToString()) * 256 * 256 + Int64.Parse(_iparray.GetValue(2).ToString()) * 256 + Int64.Parse(_iparray.GetValue(3).ToString()) - 1;
                }
                return _Int64;
            }
        }

        public static string IP
        {
            get
            {
                string result = String.Empty;
                result = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (result != null && result != String.Empty)
                {
                    //可能有代理
                    if (result.IndexOf(".") == -1) //没有"."肯定是非IPv4格式
                        result = null;
                    else
                    {
                        if (result.IndexOf(",") != -1)
                        {
                            //有","，估计多个代理。取第一个不是内网的IP。
                            result = result.Replace(" ", "").Replace("", "");
                            string[] temparyip = result.Split(",;".ToCharArray());
                            for (int i = 0; i < temparyip.Length; i++)
                            {
                                if (IsIPAddress(temparyip[i])
                                        && temparyip[i].Substring(0, 3) != "10."
                                        && temparyip[i].Substring(0, 7) != "192.168"
                                        && temparyip[i].Substring(0, 7) != "172.16.")
                                {
                                    return temparyip[i]; //找到不是内网的地址
                                }
                            }
                        }
                        else if (IsIPAddress(result)) //代理即是IP格式
                            return result;
                        else
                            result = null; //代理中的内容 非IP，取IP
                    }

                }

                string IpAddress = (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null && System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != string.Empty) ? System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] : System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                if (null == result || result == String.Empty)
                    result = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                if (result == null || result == String.Empty)
                    result = System.Web.HttpContext.Current.Request.UserHostAddress;

                return result;
            }
        }

        //是否ip格式
        public static bool IsIPAddress(string str1)
        {
            if (str1 == null || str1 == string.Empty || str1.Length < 7 || str1.Length > 15) return false;

            string regformat = @"^\\d{1,3}[\\.]\\d{1,3}[\\.]\\d{1,3}[\\.]\\d{1,3}$";

            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
            return regex.IsMatch(str1);
        }
    }
}