namespace PowerSystemMonitoring.Web.ViewModels.GeographicalCoordinates
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;

    public class EditGeographicalCoordinatesModel : IMapFrom<GeographicalCoordinates>
    {
        public int Id { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }
    }
}
