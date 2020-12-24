namespace PowerSystemMonitoring.Web.ViewModels.GeographicalCoordinates
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;

    public class GeographicalCoordinatesViewModel : IMapFrom<GeographicalCoordinates>
    {
        public int Id { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string AddedByUserUsername { get; set; }

        public string CurrentSensorName { get; set; }
    }
}
