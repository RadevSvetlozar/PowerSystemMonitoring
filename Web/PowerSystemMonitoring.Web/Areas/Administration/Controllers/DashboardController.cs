namespace PowerSystemMonitoring.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PowerSystemMonitoring.Services.Data;
    using PowerSystemMonitoring.Web.ViewModels.Administration.Dashboard;

    public class DashboardController : AdministrationController
    {
        public DashboardController()
        {
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
