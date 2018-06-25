using System.Collections.Specialized;
using System.Web.Mvc;
using RockMelon.Site.Models;
using RockMelon.Tools.Extension;

namespace RockMelon.Site.ModelBinders
{
    public class ContentModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            NameValueCollection form = controllerContext.HttpContext.Request.Form;
            var myModel = new RecipeModel();
            //myModel.MenuId = form["MenuId"].ToInt32(0);
            //myModel.PageId = form["PageId"].ToInt32(0);
            //myModel.OrderId = form["OrderId"].ToInt32(0);
            //myModel.PageTitle = form["PageTitle"];
            //myModel.PageSearchWords = form["PageSearchWords"];
            return myModel;
        }
    }
}