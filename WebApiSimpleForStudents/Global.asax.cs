using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApiSimpleForStudents
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //GlobalConfiguration.Configure(config => {
            //    config.EnableCors();
            //    config.MapHttpAttributeRoutes();
            //    config.Formatters.Clear();
            //    config.Formatters.Add(new JsonMediaTypeFormatter());
            //    config.Formatters.Add(new XmlMediaTypeFormatter());
            //});
        }
    }
}
