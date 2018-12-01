using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WeatherProject.Models
{
    public class WeatherModel : DbContext
    {
        public WeatherModel() : base("name=WeatherModel")
        {

        }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<City> Cities { get; set; }
    }


    public class Record
    {
        [Key]
        public int Id { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public double Temperature { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Source")]
        public int SourceId { get; set; }
        public Source Source { get; set; }

    }

    public class Source
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Outside { get; set; }
        public ICollection<Record> Records { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }
    }
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Source> Sources { get; set; }
    }

}