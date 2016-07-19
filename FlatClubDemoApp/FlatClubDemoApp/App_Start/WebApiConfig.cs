using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using FlatClubDemoApp.Api.ExceptionHandling;
using FlatClubDemoApp.ExceptionHandling;


namespace FlatClubDemoApp
{
   
        public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                // Web API routes
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                    name: "ActionApi",
                    routeTemplate: "api/{controller}/{action}/{id}",
                    defaults: new { id = RouteParameter.Optional });

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional });

               config.Services.Replace(typeof(IExceptionHandler), new WebApiExceptionHandler());

                config.Formatters.JsonFormatter.SerializerSettings =
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    };

                config.Filters.Add(new AppActionFilterAttribute());
                config.Filters.Add(new ModelStateValidationActionFilter());
            }
        }
    }

