namespace WeatherProject.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WeatherProject.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WeatherProject.Models.WeatherModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WeatherProject.Models.WeatherModel context)
        {
            var sport = new City { Name = "Shreveport" };
            var boss = new City { Name = "Bossier City" };

            var source1 = new Source { Name = "Ken's Pi", Outside = false, City = boss };
            var source2 = new Source { Name = "OpenWeatherMap", Outside = true, City = sport };
            var source3 = new Source { Name = "OpenWeatherMap", Outside = true, City = boss };

            context.Cities.Add(sport);
            context.Cities.Add(boss);

            context.Sources.Add(source1);
            context.Sources.Add(source2);
            context.Sources.Add(source3);


        }
    }
}
