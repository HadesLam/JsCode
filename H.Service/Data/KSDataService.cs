using H.IService;
using H.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace H.Service
{
    public class KSDataService : ServiceBase, IKSDataService
    {
        public int Add(KSData _data)
        {
            Context.BAS_KSData.Add(_data);
            return Context.SaveChanges();
        }
      
    }
}