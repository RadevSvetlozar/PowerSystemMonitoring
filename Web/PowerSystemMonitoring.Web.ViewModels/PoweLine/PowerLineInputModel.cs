namespace PowerSystemMonitoring.Web.ViewModels.PoweLine
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.AspNetCore.Http;

    public class PowerLineInputModel
    {
        public string Name { get; set; }

        public double Length { get; set; }

        public double Voltage { get; set; }

        public IFormFile Image { get; set; }
    }
}
