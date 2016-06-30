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
using BikeDataModels;

namespace BikesAPI.Controllers
{
    public class QuestionsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Questions
        [HttpGet]
        public IEnumerable<MostBikeContainer> Q1()
        {
            return db.BikeContainer
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

        [HttpGet]
        public IEnumerable<StolenBikeInMonthOfYear> Q2()
        {
            return db.Theft
                .GroupBy(theft => theft.DateTime.Year + " " + theft.DateTime.Month)
                .Select(gr => new StolenBikeInMonthOfYear { Month = gr.FirstOrDefault().DateTime.Month, Year = gr.FirstOrDefault().DateTime.Year, StolenBikes = gr.Count() })
                .ToList()
                .OrderBy(record => record.Month).OrderBy(record => record.Year);
        }

        [HttpGet]
        public IEnumerable<CombinationofTheftTrommelAreaMonth> Q3()
        {
            var _thefts = db.Theft
                .GroupBy(theft => new { hood = theft.Neighbourhood, month = theft.DateTime.Month, year = theft.DateTime.Year })
                .Select(gr => new { Neighbourhood = gr.Key.hood, Month = gr.Key.month, Year = gr.Key.year, TheftCount = gr.Count(), ContainerCount = 0 });

            var _containers = db.BikeContainer
                .GroupBy(container => new { hood = container.Neighbourhood, month = container.Date.Month, year = container.Date.Year })
                .Select(gr => new { Neighbourhood = gr.Key.hood, Month = gr.Key.month, Year = gr.Key.year, TheftCount = 0, ContainerCount = gr.Count() });

            return Queryable.Union(_thefts, _containers)
                .GroupBy(u => new { hood = u.Neighbourhood, month = u.Month, year = u.Year })
                .Select(gr => new { Neighbourhood = gr.Key.hood, Month = gr.Key.month, Year = gr.Key.year, TheftCount = gr.Sum(r => r.TheftCount), ContainerCount = gr.Sum(r => r.ContainerCount) })
                .GroupBy(row => row.Neighbourhood)
                .Select(gr => new CombinationofTheftTrommelAreaMonth {
                    Neighbourhood = gr.Key,
                    Rows = gr.Select(row => new TheftAndTrommel { Year=row.Year, Month = row.Month, Thefts=row.TheftCount, Trommels = row.ContainerCount}).OrderBy(o => new {o.Year, o.Month }) }).ToList();

                
        }

        [HttpGet]
        public IEnumerable<GetBrand> Q4a()
        {
            return db.Theft
                .Where(theft => theft.Type != "null")
                .GroupBy(theft => theft.Type)
                .Select(brandGr => new GetBrand { Brand = brandGr.Key, Count = brandGr.Count() })
                .ToList()
                .OrderByDescending(record => record.Count);
        }
        [HttpGet]
        public IEnumerable<GetColor> Q4b()
        {
            return db.Theft
                .Where(theft => theft.Color != "null")
                .GroupBy(theft => theft.Color)
                .Select(colorGr => new GetColor { Color = colorGr.Key, Count = colorGr.Count() })
                .ToList()
                .OrderByDescending(record => record.Count);
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