using H.IService;
using H.Model;
using System;
using System.Linq;

namespace H.Service
{
    public class SettingService : ServiceBase, ISettingService
    {
        public Setting Search(string _data)
        {
            return Context.BAS_Setting.Where(c => c.name == _data).FirstOrDefault();
        }
    }
}