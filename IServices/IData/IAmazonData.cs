namespace IServices
{
    public interface IAmazonData : IService
    {
        int Add(Model.AmazonData _data);
        int Update(Model.AmazonData _data);

    }
}