namespace PowerSystemMonitoring.Web.ViewModels.PoweLine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Web.WebPages.Html;

    using Microsoft.AspNetCore.Http;

    public class PowerLineInputModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]

        public double Length { get; set; }

        [Required]
        public double Voltage { get; set; }

        public int ConductorId { get; set; }

        public IEnumerable<SelectListItem> Conductors { get; set; }

        public IFormFile Image { get; set; }
    }
}
