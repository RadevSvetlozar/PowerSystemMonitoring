namespace PowerSystemMonitoring.Web.ViewModels.PoweLine
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;

    public class PowerLineViewModel : IMapFrom<PowerLine>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Length { get; set; }

        public double Voltage { get; set; }
    }
}
