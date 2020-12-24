namespace PowerSystemMonitoring.Web.ViewModels.Condutor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;

    public class ConductorViewModel : IMapFrom<Conductor>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double OuterDiameter { get; set; }

        public double InnerDiameter { get; set; }

        public double Weight { get; set; }

        public double RTCoefficient { get; set; }
        public string ImageUrl { get; set; }

        public double CoefficientOfThermalExpansion { get; set; }

        public double Elasticity { get; set; }

        public double Section { get; set; }

        public double MaxTemperature { get; set; }

        public double Current { get; set; }

        public double MaxCurrent { get; set; }

        public int ConductorPerPhase { get; set; }

        public string AddedByUserUsername { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Image { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Conductor, ConductorViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(x => x.Image.RemoteImageUrl != null ?
                x.Image.RemoteImageUrl :
                "/images/conductors/" + x.Image.Id + "." + x.Image.Extension));
        }
    }
}
