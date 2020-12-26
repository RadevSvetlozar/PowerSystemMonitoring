namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
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

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Model { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string ConnectionPassword { get; set; }

        [Required]
        [MaxLength(15)]
        public string IPAddress { get; set; }

        [Required]
        public double InstallationHeight { get; set; }

        [Required]
        public double DistancePole { get; set; }

        [Required]
        public double Orientation { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public int? AreaId { get; set; }

        public virtual Area Area { get; set; }

        public int? PowerLineId { get; set; }

        public virtual PowerLine PowerLine { get; set; }

        public int? RealTimeValuesId { get; set; }

        public virtual RealTimeValues RealTimeValues { get; set; }

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
