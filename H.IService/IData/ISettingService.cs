using H.Model;

namespace H.IService
{
    public interface ISettingService : IService
    {
        Setting Search(string _data);
    }
}