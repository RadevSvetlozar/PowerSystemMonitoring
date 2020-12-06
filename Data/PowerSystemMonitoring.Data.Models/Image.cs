namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PowerSystemMonitoring.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
            this.WeatherStations = new HashSet<WeatherStationsImages>();
            this.Conductors = new HashSet<ConductorsImages>();
            this.CurrentSensors = new HashSet<CurrentSensorsImages>();
        }

        public string Extension { get; set; }

        //// The contents of the image is in the file system

        public string RemoteImageUrl { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<CurrentSensorsImages> CurrentSensors { get; set; }

        public virtual ICollection<ConductorsImages> Conductors { get; set; }

        public virtual ICollection<WeatherStationsImages> WeatherStations { get; set; }
    }
}
