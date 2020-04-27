using H.Model;
using System.Collections.Generic;

namespace H.IService
{
    public interface IIPSiteService : IService
    {
        IPSite Search(string _countryCode);
    }
}