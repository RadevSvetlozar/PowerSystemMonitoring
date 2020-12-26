namespace PowerSystemMonitoring.Web.ViewModels.Area
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;

    public class AreaEditModel : IMapFrom<Area>, IHaveCustomMappings
    {
        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        public string Name { get; set; }

        public IFormFile ImageFile { get; set; }

        public string ImageUrl { get; set; }

        public string CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Area, AreaEditModel>()
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(x => x.Image.RemoteImageUrl != null ?
                x.Image.RemoteImageUrl :
                "/images/areas/" + x.Image.Id + "." + x.Image.Extension));
        }
    }
}
