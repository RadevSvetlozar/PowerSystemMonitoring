using CurrentSensorSeeder;

namespace PowerSystemMonitoring.Data.Models
{
 

    public class CurrentSensor 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public int? RealTimeValuesId { get; set; }

        public virtual RealTimeValues RealTimeValues { get; set; }
    }
}
