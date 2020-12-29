namespace PowerSystemMonitoring.Web.Controllers
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Web.Mvc;

    using Microsoft.AspNetCore.Mvc;
    using PowerSystemMonitoring.Services.Data;
    using PowerSystemMonitoring.Web.Hubs;
    using PowerSystemMonitoring.Web.ViewModels;
    using PowerSystemMonitoring.Web.ViewModels.CurrentSensor;
    using PowerSystemMonitoring.Web.ViewModels.PoweLine;

    public class HomeController : BaseController
    {
        private readonly ICurrentSensorService currentSensorService;

        public HomeController(ICurrentSensorService currentSensorService)
        {
            this.currentSensorService = currentSensorService;
        }

        public IActionResult Index()
        {
            var model = this.currentSensorService.GetAll<CurrentSensorViewModel>();

            return this.View(model);
        }


        public IActionResult ControlPanel()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        public IActionResult StatusCodeError(int errorCode)
        {
            return this.View();
        }
    }
}
