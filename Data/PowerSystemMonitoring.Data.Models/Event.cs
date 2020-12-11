namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    using PowerSystemMonitoring.Data.Common.Models;

    public class Event : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int? PowerLineId { get; set; }

        public virtual PowerLine PowerLine { get; set; }

        public int? CurrentSensorId { get; set; }

        public virtual CurrentSensor CurrentSensor { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }
    }
}
