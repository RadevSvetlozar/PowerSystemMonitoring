namespace PowerSystemMonitoring.Web.ViewModels.Event
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;

    public class EventViewModel : IMapFrom<Event>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string AddedByUserUsername { get; set; }
        
        public string CurrentSensorName { get; set; }

        public string PowerLineName { get; set; }

        public bool IsActive { get; set; }
    }
}
