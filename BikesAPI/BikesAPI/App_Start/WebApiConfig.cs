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
            builder.EntitySet<thefts>("thefts");

            builder.EntitySet<trommel>("trommels");
            config.Routes.MapODataServiceRoute("odata", "", builder.GetEdmModel());
        }
    }
}
