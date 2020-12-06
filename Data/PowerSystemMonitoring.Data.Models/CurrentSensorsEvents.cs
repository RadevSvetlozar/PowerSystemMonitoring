namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CurrentSensorsEvents
    {
        [Key]
        public int CurrentSensorId { get; set; }

        public virtual CurrentSensor CurrentSensor { get; set; }

        [Key]
        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
