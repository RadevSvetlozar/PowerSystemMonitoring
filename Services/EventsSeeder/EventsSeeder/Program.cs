using System;
using System.Collections.Generic;
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

            var listOfNames = new List<string>
            {
                "Overloading",
                "Undervoltage",
                "Overvoltage",
            };

            Random rnd = new Random();

            for (int i = 1; i <= 10; i++)
            {
                var sensor = sensors.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

                var name = listOfNames[rnd.Next(0, listOfNames.Count())];
                var description = $"{name} on {sensor.Name}";
                var time = DateTime.UtcNow;


                var realTimeEvents = new Event
                {
                    Name = name,
                    Description = description,
                    CreatedOn = time,
                    CurrentSensor = sensor,
                };

                Thread.Sleep(20000);

                await dbContext.Events.AddAsync(realTimeEvents);
                await dbContext.SaveChangesAsync();

                Console.WriteLine($"Send: Name = {name}; Description = {description}; Time = {time}");
            }
        }
    }
}
