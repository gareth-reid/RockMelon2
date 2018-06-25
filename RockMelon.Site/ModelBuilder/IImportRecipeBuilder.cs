using Rockmelon.Repository.Entities;
using RockMelon.Site.Models;



namespace RockMelon.Site.ModelBuilder
{
    public interface IImportRecipeBuilder
    {
        RecipeModel BuildModel(Recipe page);
        RecipeModel BuildModel(int entityId);
        Recipe BuildEntity(RecipeModel model);
        void Delete(int pageId);
        Recipe CopyAndArchive(int pageId);
        Recipe BuildEntity(int pageId);
        Recipe MoveAndArchive(int pageId);
    }
}