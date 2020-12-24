namespace PowerSystemMonitoring.Web.ViewModels.PoweLine
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web.WebPages.Html;
    using Microsoft.AspNetCore.Http;

    public class PowerLineInputModel
    {
        public string Name { get; set; }

        public double Length { get; set; }

        public double Voltage { get; set; }

        public int ConductorId { get; set; }

        public IEnumerable<SelectListItem> Conductors { get; set; }

        public IFormFile Image { get; set; }
    }
}
