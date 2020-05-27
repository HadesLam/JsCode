using H.Model;
using System.Collections.Generic;

namespace H.IService
{
    public interface IKSDataService : IService
    {
        int Add(KSData _data);
    }
}