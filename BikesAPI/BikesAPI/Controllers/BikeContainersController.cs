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

namespace BikesAPI.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using BikesAPI.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<BikeContainer>("BikeContainers");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class BikeContainersController : ODataController
    {
        private DataContext db = new DataContext();

        // GET: odata/BikeContainers
        [EnableQuery]
        public IQueryable<BikeContainer> GetBikeContainers()
        {
            return db.BikeContainers;
        }

        // GET: odata/BikeContainers(5)
        [EnableQuery]
        public SingleResult<BikeContainer> GetBikeContainer([FromODataUri] int key)
        {
            return SingleResult.Create(db.BikeContainers.Where(bikeContainer => bikeContainer.Id == key));
        }

        // PUT: odata/BikeContainers(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<BikeContainer> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BikeContainer bikeContainer = await db.BikeContainers.FindAsync(key);
            if (bikeContainer == null)
            {
                return NotFound();
            }

            patch.Put(bikeContainer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BikeContainerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(bikeContainer);
        }

        // POST: odata/BikeContainers
        public async Task<IHttpActionResult> Post(BikeContainer bikeContainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BikeContainers.Add(bikeContainer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BikeContainerExists(bikeContainer.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(bikeContainer);
        }

        // PATCH: odata/BikeContainers(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<BikeContainer> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BikeContainer bikeContainer = await db.BikeContainers.FindAsync(key);
            if (bikeContainer == null)
            {
                return NotFound();
            }

            patch.Patch(bikeContainer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BikeContainerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(bikeContainer);
        }

        // DELETE: odata/BikeContainers(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            BikeContainer bikeContainer = await db.BikeContainers.FindAsync(key);
            if (bikeContainer == null)
            {
                return NotFound();
            }

            db.BikeContainers.Remove(bikeContainer);
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

        private bool BikeContainerExists(int key)
        {
            return db.BikeContainers.Count(e => e.Id == key) > 0;
        }
    }
}
