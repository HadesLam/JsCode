using H.IService;
using H.Model;
using System;
using System.Linq;

namespace H.Service
{
    public class AmazonData : ServiceBase, IAmazonData
    {
        public int Add(AZData _data)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public AZData SearchByOrderNo(string _OrderNo)
        {
            return Context.AmazonData.Where(o => o.refrence_no_platform.Equals(_OrderNo)).FirstOrDefault();
        }

        public int Update(AZData _data)
        {
            throw new NotImplementedException();
        }
    }
}