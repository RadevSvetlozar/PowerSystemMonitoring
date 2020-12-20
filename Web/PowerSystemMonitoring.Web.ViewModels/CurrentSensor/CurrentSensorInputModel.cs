namespace PowerSystemMonitoring.Web.ViewModels.CurrentSensor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.AspNetCore.Http;

    public class CurrentSensorInputModel
    {
        public string Name { get; set; }

        public string Model { get; set; }

        public string PhoneNumber { get; set; }

        public string ConnectionPassword { get; set; }

        public string IPAddress { get; set; }

        public double InstallationHeight { get; set; }

        public double DistancePole { get; set; }

        public double Orientation { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public bool IsActive { get; set; }

        public IFormFile Image { get; set; }
    }
}
