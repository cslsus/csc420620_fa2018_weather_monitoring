using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherProject.Functions;
using WeatherProject.Models;
using WeatherProject.Persistence;

namespace WeatherProject.Controllers
{
    public class RecordController : ApiController
    {
        public class ChartJSContainer
        {
            public string[] names { get; set; }
            public double[] data { get; set; }
            public ChartJSContainer(int n)
            {
                data = new double[n];
                names = new string[n];
            }
        }
        // GET: api/Record
        [HttpGet, Route("api/records")]
        public ChartJSContainer Get()
        {
            var list = new ChartJSContainer(10);
            var recs = Db.LoadN(10,1).ToList(); //1 is ken's pi
            for (int i = 0; i < 10; i++)
            {
                list.data[i] = recs[i].Temperature;
                list.names[i] = recs[i].Date.ToShortTimeString();
            }
            return list;
        }
        // GET: api/Record/5
        [HttpGet, Route("api/records/{n}")]
        public ChartJSContainer Get(int n)
        {
            var list = new ChartJSContainer(n);
            var recs = Db.LoadN(n, 1).ToList(); //1 is ken's pi
            for (int i = 0; i < n; i++)
            {
                list.data[i] = recs[i].Temperature;
                list.names[i] = recs[i].Date.ToShortTimeString();
            }
            return list;
        }
        //GET: api/Record/2018-11-20
        [HttpGet,Route("api/records/date/{date}")]
        public List<Record> Get(string date)
        {
            return Db.LoadByDate(DateTime.Parse(date)).ToList();
        }
        [HttpGet, Route("api/records/date/{date}/source/{id}")]
        public List<Record> Get(string date, int id)
        {
            return Db.LoadByDate(DateTime.Parse(date), id).ToList();
        }

        // POST: api/Record
        [HttpPost, Route("api/record")]
        public void Post([FromBody]Record rec)
        {
            Db.Save(rec);
            var source = Db.GetSource(rec.SourceId);
            if (source.Outside == false)
                Thermostat.AdjustTemperature(source.Id);
        }
    }
}