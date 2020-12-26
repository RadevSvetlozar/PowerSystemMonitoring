namespace PowerSystemMonitoring.Web.ViewModels.Condutor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Http;

    public class ConductorInputModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [DisplayName("Outer diameter")]
        public double OuterDiameter { get; set; }

        [DisplayName("Inner diameter")]
        public double InnerDiameter { get; set; }

        public double Weight { get; set; }

        [DisplayName("RT coefficient")]
        public double RTCoefficient { get; set; }

        [DisplayName("Coefficient of thermal Expansion")]
        public double CoefficientOfThermalExpansion { get; set; }

        public double Elasticity { get; set; }

        public double Section { get; set; }

        [DisplayName("Max temperature")]
        public double MaxTemperature { get; set; }

        public double Current { get; set; }

        [DisplayName("Max current")]
        public double MaxCurrent { get; set; }

        [DisplayName("Conductor per phase")]
        public int ConductorPerPhase { get; set; }

        public IFormFile Image { get; set; }
    }
}
