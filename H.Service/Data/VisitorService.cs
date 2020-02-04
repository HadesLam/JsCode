using H.IService;
using H.Model;
using System;
using System.Linq;

namespace H.Service
{
    public class VisitorService : ServiceBase, IVisitorService
    {
        public int Add(Visitor _data)
        {
            Context.BAS_Visitor.Add(_data);
            return Context.SaveChanges();
        }
    }
}