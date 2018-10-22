using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiSimpleForStudents
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var corsAttr = new EnableCorsAttribute("http://localhost:51539", headers: "*", methods: "*");
            config.EnableCors();
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
