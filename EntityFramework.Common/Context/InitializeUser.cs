using EntityFramework.Common.Application;

namespace EntityFramework.Common.Context
{
    public class InitializeUser : ICurrentUserOfApplication
    {
        #region ICurrentUserOfApplication Members

        public string UserId
        {
            get { return "[System]"; }
        }

        #endregion
    }
}