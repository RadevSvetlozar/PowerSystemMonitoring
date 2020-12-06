namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    using PowerSystemMonitoring.Data.Common.Models;

    public class PowerLine : BaseDeletableModel<int>
    {
        public PowerLine()
        {
            this.Areas = new HashSet<PowerLinesAreas>();
            this.CurrentSensors = new HashSet<CurrentSensor>();
            this.Events = new HashSet<PowerLinesEvents>();
        }

        public string Name { get; set; }

        public double Length { get; set; }

        public double Voltage { get; set; }

        public int ConductorId { get; set; }

        public Conductor Conductor { get; set; }

        public ICollection<PowerLinesAreas> Areas { get; set; }

        public ICollection<CurrentSensor> CurrentSensors { get; set; }

        public ICollection<PowerLinesEvents> Events { get; set; }
    }
}
