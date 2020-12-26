namespace PowerSystemMonitoring.Web.ViewModels.CurrentSensor
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.WebPages.Html;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;

    public class EditCurrentSensor : IMapFrom<CurrentSensor>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(4)]
        public string Model { get; set; }

        [Required]
        [RegularExpression(@"^(\+\d{1,3}|0)\d{9}$")]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Connection password")]
        public string ConnectionPassword { get; set; }

        [Required]
        [DisplayName("IP address")]
        public string IPAddress { get; set; }

        [DisplayName("Installation height")]
        public double InstallationHeight { get; set; }

        [DisplayName("Distance pole")]
        public double DistancePole { get; set; }

        public double Orientation { get; set; }

        public string CreatedOn { get; set; }

        public bool IsActive { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int PowerLineId { get; set; }

        public IEnumerable<SelectListItem> PowerLines { get; set; }

        public IFormFile ImageFile { get; set; }

        public string ImageUrl { get; set; }

        public int WeatherStationId { get; set; }

        public IEnumerable<SelectListItem> WeatherStations { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<CurrentSensor, EditCurrentSensor>()
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(x => x.Image.RemoteImageUrl != null ?
                x.Image.RemoteImageUrl :
                "/images/currentSensors/" + x.Image.Id + "." + x.Image.Extension))
                .ForMember(x => x.PowerLineId, opt => opt.MapFrom(x => x.PowerLineId));
        }
    }
}
