using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using BikesAPI.Models;
using BikeDataModels;

namespace BikesAPI.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using BikesAPI.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<trommel>("trommels");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class trommelsController : ODataController
    {
        private Model db = new Model();

        // GET: odata/trommels
        [EnableQuery]
        public IQueryable<trommel> Gettrommels()
        {
            return db.trommel;
        }

        // GET: odata/trommels(5)
        [EnableQuery]
        public SingleResult<trommel> Gettrommel([FromODataUri] int key)
        {
            return SingleResult.Create(db.trommel.Where(trommel => trommel.id == key));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool trommelExists(int key)
        {
            return db.trommel.Count(e => e.id == key) > 0;
        }
    }
}
