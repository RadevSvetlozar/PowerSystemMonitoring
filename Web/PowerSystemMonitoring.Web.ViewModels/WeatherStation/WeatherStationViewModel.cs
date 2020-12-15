namespace PowerSystemMonitoring.Web.ViewModels.WeatherStation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;

    public class WeatherStationViewModel : IMapFrom<WeatherStation>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Temperature { get; set; }

        public string City { get; set; }

        public string IPAddress { get; set; }

        public string InstalationDescription { get; set; }

        public string AddedByUserUsername { get; set; }

        public bool IsActive { get; set; }
    }
}
