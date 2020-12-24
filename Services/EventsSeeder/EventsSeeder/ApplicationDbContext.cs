using EventsSeeder;
using Microsoft.EntityFrameworkCore;
using PowerSystemMonitoring.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrentSensorSeeder
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {

        }

        public DbSet<CurrentSensor> CurrentSensors { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<PowerLine> PowerLines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=PowerSystemMonitoring;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
