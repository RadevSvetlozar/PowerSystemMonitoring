namespace PowerSystemMonitoring.Web.ViewModels.Condutor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;

    public class ConductorEditModel : IMapFrom<Conductor>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(4)]
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

        public string ImageUrl { get; set; }

        public string CreatedOn { get; set; }

        public IFormFile ImageFile { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Conductor, ConductorEditModel>()
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(x => x.Image.RemoteImageUrl != null ?
                x.Image.RemoteImageUrl :
                "/images/conductors/" + x.Image.Id + "." + x.Image.Extension));
        }
    }
}
