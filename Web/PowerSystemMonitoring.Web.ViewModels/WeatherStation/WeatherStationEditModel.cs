namespace PowerSystemMonitoring.Web.ViewModels.WeatherStation
{
    using System;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;

    public class WeatherStationEditModel : IMapFrom<WeatherStation>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Temperature { get; set; }

        public string City { get; set; }

        public string IPAddress { get; set; }

        public string InstalationDescription { get; set; }

        public bool IsActive { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public IFormFile ImageFile { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<WeatherStation, WeatherStationEditModel>()
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(x => x.Image.RemoteImageUrl != null ?
                x.Image.RemoteImageUrl :
                "/images/weatherStations/" + x.Image.Id + "." + x.Image.Extension));
        }
    }
}
