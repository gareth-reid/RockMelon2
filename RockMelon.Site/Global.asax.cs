using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using Rockmelon.Factory;
using RockMelon.Repository.Context;

namespace RockMelon.Site
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }
       
        protected void Application_Start()
        {
            //register IOC (Ninject)
            Ioc.Container = new Factory();

            if (!Database.Exists("RockMelonContext"))
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<RockMelonContext>());
                using (var context = new RockMelonContext())
                {
                    context.Database.Initialize(true);
                }
            }

            //when you model changes, it will drop and recreate all tables but leave the rest of the database intact
            Database.SetInitializer(new RockMelonContextInitializer());
            using (var context = new RockMelonContext())
            {
                context.Database.Initialize(true);
            }

            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
        }
    }
}