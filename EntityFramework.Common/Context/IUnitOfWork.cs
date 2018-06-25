using System.Data.Entity;

namespace EntityFramework.Common.Context
{
    public interface IUnitOfWork
    {
        void Save();
    }
}