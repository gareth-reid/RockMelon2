using Rockmelon.Repository.Entities;

namespace Rockmelon.Business.Validators
{
    public interface IRecipeValidator
    {
        void Validate(Recipe game);
    }
}
