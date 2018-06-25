using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework.Common.Entities
{
    /// <summary>
    /// NOTE: because we are auditing every change, we do not want to (or need to) store a "CreatedOn" or "Created By".
    /// Those fields can be derived from the "LastUpdatedOn/By" of the very first record in the audit.
    /// </summary>
    public interface IBaseEntity 
    {
        int Id { get; }
        DateTimeOffset LastUpdatedOn { get; set; }

        string LastUpdatedByUserId { get; set; }

        bool IsActive { get; set; }
    }
}
