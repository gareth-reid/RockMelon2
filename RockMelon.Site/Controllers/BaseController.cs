using System.Web.Mvc;
using Rockmelon.Factory;
using RockMelon.Site.ModelBuilder;
using RockMelon.Site.Models;

namespace RockMelon.Site.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            //MenuBuilder = Ioc.Container.Get<IMenuBuilder>();
        }
        public bool ArchiveMode
        {
            get
            {
                if (Session["ArchiveMode"] == null)
                {
                    Session["ArchiveMode"] = false;
                }
                return (bool)Session["ArchiveMode"];
            }
            set { Session["ArchiveMode"] = value; }
        }

        public bool AccessGranted
        {
            get
            {
                return true;
                //if (Session["AccessGranted"] == null)
                //{
                //    Session["AccessGranted"] = false;
                //}
                //return (bool)Session["AccessGranted"];
            }
            set { Session["AccessGranted"] = value; }
        }

        public ActionResult RedirectHome(int pageId, int menuId, string message)
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
