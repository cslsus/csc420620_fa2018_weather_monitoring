using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherProject.Models;

namespace WeatherProject.Controllers
{
    public class TestController : ApiController
    {
        //an api and object for testing
        public class TestClass
        {
            public string [] names { get; set; }
            public double [] data { get; set; }
            public TestClass(int n)
            {
                data = new double[10];
                names = new string[10];
            }
        }
        // GET: api/Test
        [HttpGet,Route("api/test")]
        public TestClass Get()
        {
            var list = new TestClass(10);
            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                list.data[i] = rand.Next(200, 800) / 10;
                //Humidity = rand.NextDouble() * 100,
                //Pressure = (rand.NextDouble() * 40) + 980,
                list.names[i] = DateTime.Now.AddHours(-1 * i).ToString();
            }
            return list;
        }
        // GET: api/Test/5
        [HttpGet, Route("api/test/{id}")]
        public string Get(DateTime id)
        {
            return id.ToShortDateString();
        }

        // POST: api/Test
        [HttpPost, Route("api/test")]
        public Record Post([FromBody]Record rec)
        {
            var rand = new Random();
            rec.Id = rand.Next(0,10000);
            return rec;
        }
    }
}
