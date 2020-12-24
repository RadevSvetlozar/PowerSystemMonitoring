namespace PowerSystemMonitoring.Web.ViewModels.PoweLine
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.WebPages.Html;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;
    using PowerSystemMonitoring.Web.ViewModels.CurrentSensor;

    public class PowerLineEditModel : IMapFrom<PowerLine>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Length { get; set; }

        public double Voltage { get; set; }

        public string ImageUrl { get; set; }

        public int CurrentSensorId { get; set; }

        public IEnumerable<CurrentSensorViewModel> CurrentSensorsModels { get; set; }

        public DateTime CreatedOn { get; set; }

        public IFormFile ImageFile { get; set; }

        public string AddedByUserUsername { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<PowerLine, PowerLineEditModel>()
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(x => x.Image.RemoteImageUrl != null ?
                x.Image.RemoteImageUrl :
                "/images/powerLines/" + x.Image.Id + "." + x.Image.Extension));
        }
    }
}
