using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiMasterDetailWithAuthentication.Models;

namespace WebApiMasterDetailWithAuthentication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Add(new MultiPartFormDataFormater());
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
