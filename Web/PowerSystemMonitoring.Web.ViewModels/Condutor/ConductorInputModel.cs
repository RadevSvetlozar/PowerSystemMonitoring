namespace PowerSystemMonitoring.Web.ViewModels.Condutor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ConductorInputModel
    {
        [Required]
        [MaxLength(30)]
        [MinLength(4)]
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

        public bool IsActive { get; set; }
    }
}
