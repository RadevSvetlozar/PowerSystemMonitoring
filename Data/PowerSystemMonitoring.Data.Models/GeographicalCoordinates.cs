namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PowerSystemMonitoring.Data.Common.Models;

    public class GeographicalCoordinates : BaseDeletableModel<int>
    {
        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int AreaId { get; set; }

        public virtual Area Area { get; set; }
    }
}
