using System.Data.Entity;
using EntityFramework.Common.Entities;

namespace EntityFramework.Common.Context
{
    public interface IPageViewAuditableContext
    {
        DbSet<PageViewAudit> PageViewAudit { get; set; }
        void Save();
    }
}