namespace PowerSystemMonitoring.Web.ViewModels.WeatherStation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.AspNetCore.Http;

    public class WeatherStationInputModel
    {
        public string Name { get; set; }

        public double Temperature { get; set; }

        public string City { get; set; }

        public string IPAddress { get; set; }

        public string InstalationDescription { get; set; }

        public bool IsActive { get; set; }

        public IFormFile Image { get; set; }
    }
}
