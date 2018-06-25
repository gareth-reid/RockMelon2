using System.Web.Mvc;
using EntityFramework.Common.Context;
using Rockmelon.Business.Engine;
using Rockmelon.Factory;
using RockMelon.Site.ModelBuilder;
using RockMelon.Site.Models;

namespace RockMelon.Site.Controllers
{
    public class ImportRecipeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImportRecipeBuilder _pageImportRecipeModelBuilder;
        private readonly IRecipeImportEngine _recipeImportEngine;

        public ImportRecipeController()
        {
            _unitOfWork = Ioc.Container.Get<IUnitOfWork>();
            _pageImportRecipeModelBuilder = Ioc.Container.Get<IImportRecipeBuilder>();
            _recipeImportEngine = Ioc.Container.Get<IRecipeImportEngine>();
        }

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Display(int? pageId)
        {
            var model = _pageImportRecipeModelBuilder.BuildModel(pageId ?? 0);
            model.ReadOnly = true;
            return PartialView(model);
        }

        [ValidateInput(false)]
        public ActionResult Save(RecipeModel model)
        {//TODO: make this an attribute or something
            if (AccessGranted)
            {
                model.RecipeContent = model.RecipeContent;
                _recipeImportEngine.ExtractRecipe(model.RecipeContent);
                //_unitOfWork.Save();
                return RedirectHome(model.Id, 0, "Successfully Saved.");
            }
            return RedirectHome(0, 0, "No Permission.");
        }

        public ActionResult Delete(int? pageId)
        {
            _pageImportRecipeModelBuilder.Delete(pageId ?? 0);
            return RedirectHome(0, 0, "Successfully Deleted.");
        }
              
        public ActionResult Edit(int? pageId)
        {
            if (AccessGranted)
            {
                var model = _pageImportRecipeModelBuilder.BuildModel(pageId ?? 0);
                model.ReadOnly = false;
                return PartialView(model);
            }
            return RedirectHome(0, 0, "No Permission.");
        }

        public ActionResult Copy(int? pageId)
        {
            //if (AccessGranted)
            //{
            //    var pageToMove = _pageImportRecipeModelBuilder.CopyAndArchive(pageId ?? 0);
            //    _unitOfWork.Save();
            //    return RedirectHome(pageId ?? 0, pageToMove.Id, "A copy of this page has been moved to archive, you may continue editing this version.");
            //}
            return RedirectHome(0, 0, "No Permission.");
        }
    }
}
