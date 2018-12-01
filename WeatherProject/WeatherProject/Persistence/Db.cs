using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherProject.Models;

namespace WeatherProject.Persistence
{
    public static class Db
    {
        public static void Save(Record rec)
        {
            using (WeatherModel context= new WeatherModel())
            {
                context.Records.Add(rec);
                context.SaveChanges();
            }
        }
        public static Record Load(int id)
        {
            using (WeatherModel context = new WeatherModel())
            {
                return context.Records.FirstOrDefault(x => x.Id == id);
            }
        }
        public static IEnumerable<Record> LoadN(int n, int sourceId)
        {
            using (WeatherModel context = new WeatherModel())
            {
                return context.Records.Where(s => s.SourceId == sourceId).OrderByDescending(x => x.Date).Take(n).ToList();
            }
        }
        public static IEnumerable<Record> LoadAll()
        {
            using (WeatherModel context = new WeatherModel())
            {
                return context.Records.OrderByDescending(x => x.Date).ToList();
            }
        }
        public static IEnumerable<Record> LoadAll(int id)
        {
            using (WeatherModel context = new WeatherModel())
            {
                return context.Records.Where(s => s.SourceId == id).OrderByDescending(x => x.Date).ToList();
            }
        }
        public static IEnumerable<Record> LoadByDate(DateTime date)
        {
            using (WeatherModel context = new WeatherModel())
            {
                return context.Records.Where(r => r.Date.Day == date.Day && r.Date.Month == date.Month && r.Date.Year == date.Year).ToList();
            }
        }
        public static IEnumerable<Record> LoadByDate(DateTime date, int sourceId)
        {
            using (WeatherModel context = new WeatherModel())
            {
                return context.Records.Where(r => r.SourceId == sourceId).Where(r => r.Date.Day == date.Day && r.Date.Month == date.Month && r.Date.Year == date.Year).ToList();
            }
        }
        public static IEnumerable<Record> LoadByDateRange(DateTime dateFrom, DateTime dateTo)
        {
            using (WeatherModel context = new WeatherModel())
            {
                return context.Records.Where(r => r.Date >= dateFrom && r.Date <= dateTo).ToList();
            }
        }
        public static Source GetSource(int id)
        {
            using (WeatherModel context = new WeatherModel())
            {
                return context.Sources.FirstOrDefault(s => s.Id == id);
            }
        }
        public static IEnumerable<Source> GetSources()
        {
            using (WeatherModel context = new WeatherModel())
            {
                return context.Sources.ToList();
            }
        }
        public static string GetPrediction(int sourceId) {
            using (WeatherModel context = new WeatherModel())
            {
                string pred = "Prediction unavailable.";

                if (!context.Sources.FirstOrDefault(s => s.Id == sourceId).Outside)
                    pred = "Source is not outside. " + pred;
                else
                {
                    var yesterday = DateTime.Now.AddDays(-1).Day;
                    var mostRecent = context.Records.OrderByDescending(r => r.Date).FirstOrDefault(s => s.SourceId == sourceId);
                    var lastRecord = context.Records.OrderByDescending(r => r.Date).Where(r => r.Date.Hour <= DateTime.Now.Hour && r.Date.Day == yesterday).FirstOrDefault(s => s.SourceId == sourceId);
                    pred = "Temperature: " + ((mostRecent.Temperature + lastRecord.Temperature) / 2).ToString();
                    if (lastRecord.Pressure > mostRecent.Pressure) {

                        if (lastRecord.Pressure > mostRecent.Pressure + 10)
                            pred += " Chance of rain.";
                        else
                            pred += " Slight chance of rain";
                    }else
                        pred += " Fair Weather.";
                }

                return pred;
            }
        }
    }
}