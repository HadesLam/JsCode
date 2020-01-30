using Model;

namespace IServices
{
    public interface IAmazonData : IService
    {
        int Add(AmazonData _data);
        int Update(AmazonData _data);
        AmazonData SearchByOrderNo(string _OrderNo);
    }
}