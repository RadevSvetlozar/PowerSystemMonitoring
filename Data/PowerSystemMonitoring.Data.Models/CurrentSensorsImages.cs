namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CurrentSensorsImages
    {
        public int CurrentSensorId { get; set; }

        public virtual CurrentSensor CurrentSensor { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}
