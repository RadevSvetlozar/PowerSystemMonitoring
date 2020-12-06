namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.AspNetCore.Http;
    using PowerSystemMonitoring.Data.Common.Models;

    public class Conductor : BaseDeletableModel<int>
    {
        public Conductor()
        {
            this.Images = new HashSet<Image>();
            this.CurrentSensors = new HashSet<CurrentSensor>();
        }

        public string Name { get; set; }

        public double Length { get; set; }

        public double OuterDiameter { get; set; }

        public double InnerDiameter { get; set; }

        public double Weight { get; set; }

        public double RTCoefficient { get; set; }

        public double CoefficientOfThermalExpansion { get; set; }

        public double Elasticity { get; set; }

        public double Section { get; set; }

        public double MaxTemperature { get; set; }

        public double Current { get; set; }

        public double MaxCurrent { get; set; }

        public int ConductorPerPhase { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int CurrentSensorId { get; set; }

        public int AreaId { get; set; }

        public virtual Area Area { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<CurrentSensor> CurrentSensors { get; set; }
    }
}
