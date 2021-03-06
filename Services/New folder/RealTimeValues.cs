﻿using PowerSystemMonitoring.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrentSensorSeeder
{
    public class RealTimeValues
    {
        public int Id { get; set; }

        public int? CurrentSensorId { get; set; }

        public virtual CurrentSensor CurrentSensor { get; set; }

        public DateTime Time { get; set; }

        public float Current { get; set; }

        public float Temparature { get; set; }
    }
}
