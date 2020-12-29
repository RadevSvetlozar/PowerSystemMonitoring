namespace PowerSystemMonitoring.Web.ViewModels.RealTImeCurrentSensor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;

    public class RealTimeCurrentSensorViewModel : IMapFrom<RealTimeValues>
    {
        public string Current { get; set; }

        public string Temperature { get; set; }

        public string CurrentSensorName { get; set; }

        public string CurrentSensorId { get; set; }
    }
}
