namespace PowerSystemMonitoring.Web.ViewModels.CurrentSensor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.WebPages.Html;

    using Microsoft.AspNetCore.Http;

    public class CurrentSensorInputModel
    {
        [Required]
        [MaxLength(25)]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(4)]
        public string Model { get; set; }

        [Required]

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Connection password")]
        public string ConnectionPassword { get; set; }

        [DisplayName("IP address")]
        public string IPAddress { get; set; }

        [DisplayName("Installation height")]
        public double InstallationHeight { get; set; }

        [DisplayName("Distance pole")]
        public double DistancePole { get; set; }

        public double Orientation { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public bool IsActive { get; set; }

        public IFormFile Image { get; set; }

        public int WeatherStationId { get; set; }

        public IEnumerable<SelectListItem> WeatherStations { get; set; }
    }
}
