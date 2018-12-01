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
    public class SourcesController : ApiController
    {

        // GET: api/Sources
        public IEnumerable<Source> GetSources()
        {
            return Db.GetSources();
        }

        // GET: api/Sources/5
        //Return all records for particular source
        public IEnumerable<Record> GetSource(int id)
        {
            return Db.LoadAll(id);
        }
    }
}