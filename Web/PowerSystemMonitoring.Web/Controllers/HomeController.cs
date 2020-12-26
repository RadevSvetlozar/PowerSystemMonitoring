namespace PowerSystemMonitoring.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using PowerSystemMonitoring.Services.Data;
    using PowerSystemMonitoring.Web.ViewModels;
    using PowerSystemMonitoring.Web.ViewModels.PoweLine;

    public class HomeController : BaseController
    {
        private readonly IPowerLineService powerLineService;

        public HomeController(IPowerLineService powerLineService)
        {
            this.powerLineService = powerLineService;
        }
        public IActionResult Index()
        {
            var model = powerLineService.GetAll<PowerLineViewModel>();

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
