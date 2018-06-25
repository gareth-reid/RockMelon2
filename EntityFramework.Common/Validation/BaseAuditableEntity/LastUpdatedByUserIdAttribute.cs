namespace EntityFramework.Common.Validation.BaseAuditableEntity
{
    public class LastUpdatedByUserIdAttribute : UserIdAttribute
    {
        public LastUpdatedByUserIdAttribute() : base(true)
        {
        }
    }
}