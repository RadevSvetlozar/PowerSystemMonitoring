namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PowerSystemMonitoring.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Extension { get; set; }

        //// The contents of the image is in the file system

        public string RemoteImageUrl { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        public int? ConductorId { get; set; }

        public virtual Conductor Conductor { get; set; }

        public int? CurrentSensorId { get; set; }

        public virtual CurrentSensor CurrentSensor { get; set; }

        public int? WeatherStationId { get; set; }

        public virtual WeatherStation WeatherStation { get; set; }

        public int? AreaId { get; set; }

        public virtual Area Area { get; set; }

        public int? PowerLineId { get; set; }

        public virtual PowerLine PowerLine { get; set; }
    }
}
