namespace PowerSystemMonitoring.Web.Areas.Administration.Controllers
{
    using PowerSystemMonitoring.Common;
    using PowerSystemMonitoring.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
