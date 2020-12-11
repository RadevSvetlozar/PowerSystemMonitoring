namespace PowerSystemMonitoring.Web.ViewModels.Area
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.AspNetCore.Http;

    public class AreaInputModel
    {
        public string Name { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }
    }
}
