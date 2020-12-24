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


            for (int i = 1; i <= 10; i++)
            {
                Random rnd = new Random();

                var current = (float)rnd.Next(100, 150);
                var temparature = (float)rnd.Next(20, 40);
                var time = DateTime.UtcNow;

                var realTimeValues = new RealTimeValues
                {
                    Current = current,
                    Temparature = temparature,
                    CreatedOn = time,
                };

                Thread.Sleep(20000);

                await dbContext.RealTimeValues.AddAsync(realTimeValues);
                await dbContext.SaveChangesAsync();

                Console.WriteLine($"Send: I = {current}; T = {temparature}; Time = {time}");

            }
        }
    }
}

