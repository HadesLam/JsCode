using H.IService;
using H.Model;
using System;
using System.Linq;

namespace H.Service
{
    public class MCDataService : ServiceBase, IMCDataService
    {
        public int Add(MCData _data)
        {
            Context.BAS_MCData.Add(_data);
            return Context.SaveChanges();
        }

        public int Update(MCData _data)
        {
            var _MCData = Context.BAS_MCData.Where(o => o.buyer_orderno.Equals(_data.buyer_orderno) && o.buyer_email.Equals(_data.buyer_email)).OrderByDescending(o => o.Id).FirstOrDefault();
            _MCData.buyer_customer_reviews = _data.buyer_customer_reviews;
            return Context.SaveChanges();
        }
    }
}