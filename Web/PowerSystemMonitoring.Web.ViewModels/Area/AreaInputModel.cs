namespace PowerSystemMonitoring.Web.ViewModels.Area
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Http;

    public class AreaInputModel
    {
        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        public string Name { get; set; }

        public IFormFile Image { get; set; }
    }
}
