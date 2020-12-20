namespace PowerSystemMonitoring.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using PowerSystemMonitoring.Services.Data;

    public class PowerSystemLoadsController : Controller
    {
        private readonly IPowerSystemLoad powerSystemLoad;

        public PowerSystemLoadsController(IPowerSystemLoad powerSystemLoad)
        {
            this.powerSystemLoad = powerSystemLoad;
        }

        public IActionResult GetAllLoads()
        {
            var loads = this.powerSystemLoad.GetLoad();

            return this.View(loads);
        }
    }
}
