using System.Web.Mvc;
using Rockmelon.Business.Configuration;
using Rockmelon.Factory;
using RockMelon.Site.ModelBuilder;
using RockMelon.Site.Models;

namespace RockMelon.Site.Controllers
{
    public class HomeController : BaseController
    {
       
        public ActionResult Index()
        {
            return View();
        }
        
        
       
        //temp until login is needed
        public ActionResult Access(string password)
        {
            if (!string.IsNullOrEmpty(password) && string.Equals(password, Security.Password))
            {
                AccessGranted = true;
            }
            return RedirectHome(0, 0, "Success");
        }
    }
}
