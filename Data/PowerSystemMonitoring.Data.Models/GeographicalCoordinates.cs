namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PowerSystemMonitoring.Data.Common.Models;

    public class GeographicalCoordinates : BaseDeletableModel<int>
    {
        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        public int? CurrentSensorId { get; set; }

        public CurrentSensor CurrentSensor { get; set; }
    }
}
