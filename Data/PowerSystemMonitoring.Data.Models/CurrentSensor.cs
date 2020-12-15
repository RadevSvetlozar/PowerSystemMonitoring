namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    using Microsoft.AspNetCore.Http;
    using PowerSystemMonitoring.Data.Common.Models;

    public class CurrentSensor : BaseDeletableModel<int>
    {
        public CurrentSensor()
        {
            this.Events = new HashSet<Event>();
        }

        public string Name { get; set; }

        public string Model { get; set; }

        public string PhoneNumber { get; set; }

        public string ConnectionPassword { get; set; }

        public string IPAddress { get; set; }

        public double InstallationHeight { get; set; }

        public double DistancePole { get; set; }

        public double Orientation { get; set; }

        public bool IsActive { get; set; }

        public int? AreaId { get; set; }

        public virtual Area Area { get; set; }

        public int? PowerLineId { get; set; }

        public virtual PowerLine PowerLine { get; set; }

        public int? GeographicalCoordinatesId { get; set; }

        public virtual GeographicalCoordinates GeographicalCoordinates { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public int? WeatherStationId { get; set; }

        public virtual WeatherStation WeatherStation { get; set; }

        public string ImageId { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
