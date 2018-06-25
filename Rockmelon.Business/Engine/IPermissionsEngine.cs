namespace Rockmelon.Business.Engine
{
    public interface IPermissionsEngine
    {
        bool Edit(bool access);
        bool Add(bool access);
        bool Delete(bool access);
        bool Archive(bool access);
    }
}