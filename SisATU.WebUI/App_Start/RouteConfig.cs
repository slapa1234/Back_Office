using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SisATU.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                   //defaults: new { controller = "Electronico", action = "Index", id = UrlParameter.Optional }
                //  defaults: new { controller = "Acceso", action = "Inicio", id = UrlParameter.Optional }
                   defaults: new { controller = "BackOffice", action = "LoginBackOffice", id = UrlParameter.Optional }


            //defaults: new { controller = "Acceso", action = "Index", id = UrlParameter.Optional }
            //defaults: new { controller = "Acceso", action = "Inicio", id = UrlParameter.Optional }
            //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
