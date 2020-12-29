using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CurrentSensorSeeder
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var dbContext = new ApplicationDbContext();


            var sensors = dbContext.CurrentSensors.ToList();

            Console.WriteLine("Starting...");


            for (int i = 1; i <= 50; i++)
            {
                Random rnd = new Random();

                var current = (float)rnd.Next(100, 150);
                var temparature = (float)rnd.Next(20, 40);
                var time = DateTime.UtcNow;
                var sensor = sensors.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

                var realTimeValues = new RealTimeValues
                {
                    CurrentSensorId = sensor.Id,
                    Current = current,
                    Temparature = temparature,
                    CreatedOn = time,
                };

                Thread.Sleep(500);

                await dbContext.RealTimeValues.AddAsync(realTimeValues);
                await dbContext.SaveChangesAsync();

                Console.WriteLine($"Send to Sensor{sensor.Name}: I = {current}; T = {temparature}; Time = {time}");

            }
        }
    }
}

