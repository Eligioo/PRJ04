using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using BikesAPI.Models;
using BikeDataModels;

namespace BikesAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Theft>("Thefts");
            builder.EntitySet<BikeContainer>("BikeContainers");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
