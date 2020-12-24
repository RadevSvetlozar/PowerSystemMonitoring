using PowerSystemMonitoring.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerSystemMonitoring.Data.Models
{
    public class RealTimeValues : BaseDeletableModel<int>
    {
        public int? CurrentSensorId { get; set; }

        public virtual CurrentSensor CurrentSensor { get; set; }

        public float Current { get; set; }

        public float Temparature { get; set; }
    }
}
