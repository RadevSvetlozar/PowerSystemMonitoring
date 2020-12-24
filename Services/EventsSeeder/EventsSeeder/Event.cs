using EventsSeeder;
using PowerSystemMonitoring.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrentSensorSeeder
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? CurrentSensorId { get; set; }

        public bool IsActive { get; set; } = true;

        public virtual CurrentSensor CurrentSensor { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; } = false;


    }
}
