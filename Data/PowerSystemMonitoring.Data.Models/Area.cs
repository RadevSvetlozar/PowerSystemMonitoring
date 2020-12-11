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
            this.PowerLines = new HashSet<PowerLinesAreas>();
            this.Images = new HashSet<Image>();
        }

        public string Name { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<CurrentSensor> CurrentSensors { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public ICollection<PowerLinesAreas> PowerLines { get; set; }
    }
}
