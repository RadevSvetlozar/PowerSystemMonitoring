namespace PowerSystemMonitoring.Web.ViewModels.Area
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;

    public class AreaViewModel : IMapFrom<Area>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AddedByUserUsername { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Area, AreaViewModel>()
                    .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x => x.Images.FirstOrDefault().RemoteImageUrl != null ?
                    x.Images.FirstOrDefault().RemoteImageUrl :
                    "/images/areas/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
