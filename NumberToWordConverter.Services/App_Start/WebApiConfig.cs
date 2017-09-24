using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web.Http;

namespace NumberToWordConverter.Services
{
    /// <summary>
    /// WebApiConfig
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class WebApiConfig
    {
        /// <summary>
        /// Register Routes Class
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            #region Web API Routes
           
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "ConvertWords",
               routeTemplate: "api/Convert/ConvertWords",
               defaults: new { controller = "Convert", action = "ConvertWords", id = RouteParameter.Optional }
           );
            #endregion
        }
    }
}
