using System;
using System.Linq;

namespace CurrentSensorSeeder
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new ApplicationDbContext();


            var sensors = dbContext.CurrentSensors.ToList();

            foreach (var sensor in sensors)
            {
                Console.WriteLine(sensor.Name);
            }
        }
    }
}
