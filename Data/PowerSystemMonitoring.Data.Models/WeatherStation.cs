﻿namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.AspNetCore.Http;
    using PowerSystemMonitoring.Data.Common.Models;

    public class WeatherStation : BaseDeletableModel<int>
    {
        public WeatherStation()
        {
            this.CurrentSensors = new HashSet<CurrentSensor>();
        }

        public string Name { get; set; }

        public double Temperature { get; set; }

        public string City { get; set; }

        public string IPAddress { get; set; }

        public bool IsActive { get; set; }

        public string InstalationDescription { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public int? GeographicalCoordinatesId { get; set; }

        public virtual GeographicalCoordinates GeographicalCoordinates { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<CurrentSensor> CurrentSensors { get; set; }
    }
}
