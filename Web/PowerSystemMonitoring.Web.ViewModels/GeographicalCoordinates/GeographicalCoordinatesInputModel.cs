namespace PowerSystemMonitoring.Web.ViewModels.GeographicalCoordinates
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class GeographicalCoordinatesInputModel
    {
        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }

        public string AddedByUserUsername { get; set; }
    }
}
