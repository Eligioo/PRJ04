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
using System.Web.Http.Description;
using BikesAPI.Models;

namespace BikesAPI.Controllers
{
    public class QuestionsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Questions
        public IEnumerable<MostBikeContainer> GetQ1()
        {
            return db.BikeContainers
                .GroupBy(bc => bc.Area)
                .Select
                (
                    gr =>
                        new MostBikeContainer
                        {
                            Count = gr.Count(),
                            Neighborhoods = gr.Key
                        }
                )
                .Take(5).ToList();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}