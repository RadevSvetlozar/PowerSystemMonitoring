namespace PowerSystemMonitoring.Web.ViewModels.WeatherStation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Http;

    public class WeatherStationInputModel
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public double Temperature { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [DisplayName("IP address")]
        public string IPAddress { get; set; }

        [DisplayName("Instalation description")]
        public string InstalationDescription { get; set; }

        [DisplayName("Is active")]
        public bool IsActive { get; set; }

        public IFormFile Image { get; set; }
    }
}
