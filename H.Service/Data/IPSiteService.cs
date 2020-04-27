using H.IService;
using H.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace H.Service
{
    public class IPSiteService : ServiceBase, IIPSiteService
    {
        public IPSite Search(string _countryCode)
        {
            return Context.BAS_IPSite.Where(o => o.countryCode == _countryCode.ToUpper() || o.countryCode == "GLOBLE").OrderByDescending(o => o.Id).FirstOrDefault();
        }
    }
}