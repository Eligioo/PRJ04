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
    builder.EntitySet<thefts>("thefts");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class theftsController : ODataController
    {
        private Model db = new Model();

        // GET: odata/thefts
        [EnableQuery]
        public IQueryable<thefts> Getthefts()
        {
            return db.thefts;
        }

        // GET: odata/thefts(5)
        [EnableQuery]
        public SingleResult<thefts> Getthefts([FromODataUri] int key)
        {
            return SingleResult.Create(db.thefts.Where(thefts => thefts.id == key));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool theftsExists(int key)
        {
            return db.thefts.Count(e => e.id == key) > 0;
        }
    }
}
