namespace PowerSystemMonitoring.Web.ViewModels.CurrentSensor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using AutoMapper;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;

    public class CurrentSensorViewModel : IMapFrom<CurrentSensor>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public string PhoneNumber { get; set; }

        public string ConnectionPassword { get; set; }

        public string IPAddress { get; set; }

        public double InstallationHeight { get; set; }

        public double DistancePole { get; set; }

        public double Orientation { get; set; }

        public string CreatedOn { get; set; }

        public bool IsActive { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int PowerLineId { get; set; }

        public IEnumerable<SelectListItem> PowerLines { get; set; }

        public string ImageUrl { get; set; }

        public string PowerLineName { get; set; }

        public string AddedByUserUsername { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<CurrentSensor, CurrentSensorViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(x => x.Image.RemoteImageUrl != null ?
                x.Image.RemoteImageUrl :
                "/images/currentSensors/" + x.Image.Id + "." + x.Image.Extension))
                .ForMember(x => x.PowerLineId, opt => opt.MapFrom(x => x.PowerLineId));
        }
    }
}
