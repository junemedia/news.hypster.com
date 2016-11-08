using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace hypster_news
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            //--------------------------------------------------------------------------------------------
            routes.MapRoute(
                name: "VDefault",
                url: "post/{post_guid}",
                defaults: new { controller = "post", action = "getPost", post_guid = "" }
            );
            //--------------------------------------------------------------------------------------------


            //--------------------------------------------------------------------------------------------
            routes.MapRoute(
                name: "PDefault",
                url: "page/{page_id}",
                defaults: new { controller = "home", action = "getPage", page_id = "" }
            );
            //--------------------------------------------------------------------------------------------





            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}