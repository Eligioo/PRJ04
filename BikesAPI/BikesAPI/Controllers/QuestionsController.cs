﻿using System;
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
        [HttpGet]
        public IEnumerable<MostBikeContainer> Q1()
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

        [HttpGet]
        public IEnumerable<StolenBikeInMonthOfYear> Q2()
        {
            return db.Thefts
                .GroupBy(theft => theft.DateTime.Year + " " + theft.DateTime.Month)
                .Select(gr => new StolenBikeInMonthOfYear { Month = gr.FirstOrDefault().DateTime.Month, Year = gr.FirstOrDefault().DateTime.Year, StolenBikes = gr.Count() })
                .ToList()
                .OrderBy(record => record.Month).OrderBy(record => record.Year);
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