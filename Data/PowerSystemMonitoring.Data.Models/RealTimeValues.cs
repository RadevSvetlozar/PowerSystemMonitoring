namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using PowerSystemMonitoring.Data.Common.Models;

    public class RealTimeValues : BaseDeletableModel<int>
    {
        public int? CurrentSensorId { get; set; }

        public virtual CurrentSensor CurrentSensor { get; set; }

        [Required]
        public float Current { get; set; }

        [Required]
        public float Temparature { get; set; }
    }
}
