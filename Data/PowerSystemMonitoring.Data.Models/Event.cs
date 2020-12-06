namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    using PowerSystemMonitoring.Data.Common.Models;

    public class Event : BaseDeletableModel<int>
    {
        public Event()
        {
            this.PowerLines = new HashSet<PowerLinesEvents>();
            this.CurrentSensors = new HashSet<CurrentSensorsEvents>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<PowerLinesEvents> PowerLines { get; set; }

        public virtual ICollection<CurrentSensorsEvents> CurrentSensors { get; set; }
    }
}
