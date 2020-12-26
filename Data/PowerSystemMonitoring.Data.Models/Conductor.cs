namespace PowerSystemMonitoring.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Http;
    using PowerSystemMonitoring.Data.Common.Models;

    public class Conductor : BaseDeletableModel<int>
    {
        public Conductor()
        {
            this.PowerLines = new HashSet<PowerLine>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public double OuterDiameter { get; set; }

        [Required]
        public double InnerDiameter { get; set; }

        [Required]

        public double Weight { get; set; }

        [Required]

        public double RTCoefficient { get; set; }

        [Required]

        public double CoefficientOfThermalExpansion { get; set; }

        [Required]

        public double Elasticity { get; set; }

        [Required]

        public double Section { get; set; }

        [Required]
        public double MaxTemperature { get; set; }

        [Required]
        public double Current { get; set; }

        [Required]
        public double MaxCurrent { get; set; }

        [Required]
        public int ConductorPerPhase { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public string ImageId { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<PowerLine> PowerLines { get; set; }
    }
}
