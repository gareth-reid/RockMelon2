using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework.Common.Application
{
    public interface ICurrentUserOfApplication
    {
        string UserId { get; }
    }
}
