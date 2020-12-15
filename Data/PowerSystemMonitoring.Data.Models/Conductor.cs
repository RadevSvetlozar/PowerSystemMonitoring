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
            this.PowerLines = new HashSet<PowerLine>();
        }

        public string Name { get; set; }

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

        public string ImageId { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<PowerLine> PowerLines { get; set; }
    }
}
