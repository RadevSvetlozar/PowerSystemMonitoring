using CurrentSensorSeeder;
using System;
using System.Collections.Generic;

namespace PowerSystemMonitoring.Data.Models
{
    public class CurrentSensor 
    {
        public CurrentSensor()
        {
            this.RealTimeValues = new HashSet<RealTimeValues>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<RealTimeValues> RealTimeValues { get; set; }
    }
}
