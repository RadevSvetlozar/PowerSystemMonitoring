namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using PowerSystemMonitoring.Data.Common.Models;

    public class GeographicalCoordinates : BaseDeletableModel<int>
    {
        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        public int? CurrentSensorId { get; set; }

        public CurrentSensor CurrentSensor { get; set; }
    }
}
