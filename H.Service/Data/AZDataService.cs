using H.IService;
using H.Model;
using System;
using System.Linq;

namespace H.Service
{
    public class AZDataService : ServiceBase, IAZDataService
    {
        public int Add(AZData _data)
        {
            throw new NotImplementedException();
        }

        public int Update(AZData _data)
        {
            throw new NotImplementedException();
        }

        public AZData SearchByOrderNo(string _OrderNo)
        {
            return Context.BAS_AZData.Where(o => _OrderNo.Contains(o.refrence_no_platform)).OrderByDescending(o => o.Id).FirstOrDefault();
        }
    }
}