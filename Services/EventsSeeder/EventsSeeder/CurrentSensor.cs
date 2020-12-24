using CurrentSensorSeeder;
using EventsSeeder;
using System.Collections.Generic;
using System.Security.Principal;

namespace PowerSystemMonitoring.Data.Models
{
 

    public class CurrentSensor 
    {
        public CurrentSensor()
        {
            this.Events = new HashSet<Event>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }
        public bool IsDeleted { get; set; } = false;

        public int? PowerLineId { get; set; }
        public virtual PowerLine PowerLine { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
