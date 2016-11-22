using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Asp.Net.CORS.WebConfig.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // EnableCors(config);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void EnableCors(HttpConfiguration config)
        {
            var corsUrls = ConfigurationManager.AppSettings["CorsUrlsConcatinated"].ToString();
            // Note: seems like seeting corsUrls to "http://localhost:16980" does not work. Gets blocked by
            // chrome ??? - some bug but * works!
            // But works for the IE
            var cors = new EnableCorsAttribute(corsUrls, "*", "*");
            config.EnableCors(cors);
        }
    }
}
