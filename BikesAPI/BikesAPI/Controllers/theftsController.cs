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
    builder.EntitySet<Thefts>("Thefts");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class TheftsController : ODataController
    {
        private DataContext db = new DataContext();

        // GET: odata/Thefts
        [EnableQuery]
        public IQueryable<Theft> GetThefts()
        {
            return db.Theft;
        }

        // GET: odata/Thefts(5)
        [EnableQuery]
        public SingleResult<Theft> GetThefts([FromODataUri] int key)
        {
            return SingleResult.Create(db.Theft.Where(thefts => thefts.Id == key));
        }

        // PUT: odata/Thefts(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Theft> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Theft thefts = await db.Theft.FindAsync(key);
            if (thefts == null)
            {
                return NotFound();
            }

            patch.Put(thefts);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TheftsExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(thefts);
        }

        // POST: odata/Thefts
        public async Task<IHttpActionResult> Post(Theft thefts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Theft.Add(thefts);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TheftsExists(thefts.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(thefts);
        }

        // PATCH: odata/Thefts(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Theft> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Theft thefts = await db.Theft.FindAsync(key);
            if (thefts == null)
            {
                return NotFound();
            }

            patch.Patch(thefts);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TheftsExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(thefts);
        }

        // DELETE: odata/Thefts(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Theft thefts = await db.Theft.FindAsync(key);
            if (thefts == null)
            {
                return NotFound();
            }

            db.Theft.Remove(thefts);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TheftsExists(int key)
        {
            return db.Theft.Count(e => e.Id == key) > 0;
        }
    }
}
