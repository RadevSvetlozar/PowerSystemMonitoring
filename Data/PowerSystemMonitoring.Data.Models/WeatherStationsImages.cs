namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class WeatherStationsImages
    {
        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        public int WeatherStationId { get; set; }

        public virtual WeatherStation WeatherStation { get; set; }
    }
}
