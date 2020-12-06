namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PowerSystemMonitoring.Data.Common.Models;

    public class Area : BaseDeletableModel<int>
    {
        public Area()
        {
            this.CurrentSensors = new HashSet<CurrentSensor>();
            this.GeographicalCoordinates = new HashSet<GeographicalCoordinates>();
            this.Images = new HashSet<Image>();
            this.PowerLines = new HashSet<PowerLinesAreas>();
        }

        public string Name { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<GeographicalCoordinates> GeographicalCoordinates { get; set; }

        public virtual ICollection<CurrentSensor> CurrentSensors { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public ICollection<PowerLinesAreas> PowerLines { get; set; }
    }
}
