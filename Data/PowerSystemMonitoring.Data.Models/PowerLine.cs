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
            this.CurrentSensors = new HashSet<CurrentSensor>();
        }

        public string Name { get; set; }

        public double Length { get; set; }

        public double Voltage { get; set; }

        public int? ConductorId { get; set; }

        public Conductor Conductor { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        public ICollection<Area> Areas { get; set; }

        public ICollection<CurrentSensor> CurrentSensors { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
