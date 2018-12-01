using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WeatherProject.Models;
using WeatherProject.Persistence;

namespace WeatherProject.Controllers
{
    public class PredictionsController : ApiController
    {

        // GET: api/Predictions
        public List<string> GetSources()
        {
            List<string> preds = new List<string>();
            foreach (Source s in Db.GetSources()) {
                preds.Add(s.Name + ": " + Db.GetPrediction(s.Id));
            }

            return preds;
        }

        // GET: api/Predictions/5
        [ResponseType(typeof(Source))]
        public IHttpActionResult GetSource(int id)
        {
            return Ok(Db.GetPrediction(id));
        }
    }
}