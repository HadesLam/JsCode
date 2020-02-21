using H.Model;

namespace H.IService
{
    public interface IMCDataService : IService
    {
        int Add(MCData _data);
        int Update(MCData _data);
    }
}