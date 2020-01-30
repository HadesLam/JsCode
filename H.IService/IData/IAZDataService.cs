using H.Model;

namespace H.IService
{
    public interface IAZDataService : IService
    {
        int Add(AZData _data);
        int Update(AZData _data);
        AZData SearchByOrderNo(string _OrderNo);
    }
}