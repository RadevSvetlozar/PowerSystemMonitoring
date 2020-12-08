namespace PowerSystemMonitoring.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Data;
    using PowerSystemMonitoring.Web.ViewModels.Condutor;

    public class ConductorsController : Controller
    {
        private readonly IConductorService conductorService;
        private readonly UserManager<ApplicationUser> userManager;

        public ConductorsController(
            IConductorService conductorService,
            UserManager<ApplicationUser> userManager)
        {
            this.conductorService = conductorService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(ConductorInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.User);

            await this.conductorService.CreateAsync(input, user.Id);

            this.TempData["Message"] = "Conductor added successfully.";

            return this.RedirectToAction("All");
        }

        [Authorize]
        public IActionResult All()
        {
            var conductors = this.conductorService.GetAll<ConductorViewModel>();

            return this.View(conductors);
        }

        [Authorize]
        public IActionResult GetById(int id)
        {
            var conductor = this.conductorService.GetById<ConductorViewModel>(id);

            return this.View(conductor);
        }
    }
}
