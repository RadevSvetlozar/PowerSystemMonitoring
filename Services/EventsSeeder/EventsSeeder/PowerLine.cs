using CurrentSensorSeeder;
using PowerSystemMonitoring.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventsSeeder
{
    public class PowerLine
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedOn { get; set; }

        public ICollection<CurrentSensor> CurrentSensors { get; set; } = new HashSet<CurrentSensor>();
        public ICollection<Event> Events { get; set; } = new HashSet<Event>();


    }
}
