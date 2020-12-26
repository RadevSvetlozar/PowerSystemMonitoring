namespace PowerSystemMonitoring.Web.ViewModels.WeatherStation
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;

    public class WeatherStationEditModel : IMapFrom<WeatherStation>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public double Temperature { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [DisplayName("IP address")]
        public string IPAddress { get; set; }

        [DisplayName("Instalation description")]
        public string InstalationDescription { get; set; }

        [DisplayName("Is active")]
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
