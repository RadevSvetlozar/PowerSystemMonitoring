namespace PowerSystemMonitoring.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment webHostEnvironment;

        public ConductorsController(
            IConductorService conductorService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment webHostEnvironment)
        {
            this.conductorService = conductorService;
            this.userManager = userManager;
            this.webHostEnvironment = webHostEnvironment;
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

            await this.conductorService.CreateAsync(input, user.Id, $"{this.webHostEnvironment.WebRootPath}/images");

            this.TempData["Message"] = "Conductor added successfully.";

            return this.RedirectToAction("All");
        }

        [Authorize]
        public IActionResult All()
        {
            var conductors = this.conductorService.GetAll<ConductorViewModel>();

            return this.View(conductors);
        }

        public IActionResult GetById(int id)
        {
            var currentEvent = this.conductorService.GetById<ConductorViewModel>(id);

            return this.View(currentEvent);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var inputModel = this.conductorService.GetById<ConductorViewModel>(id);

            return this.View(inputModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ConductorEditModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.User);

            await this.conductorService.UpdateAsync(id, input, user.Id, $"{this.webHostEnvironment.WebRootPath}/images");

            return this.RedirectToAction(nameof(this.All), new { id });
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            this.conductorService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
