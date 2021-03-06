﻿namespace PowerSystemMonitoring.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.WebPages.Html;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using PowerSystemMonitoring.Common;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Data;
    using PowerSystemMonitoring.Web.ViewModels.Condutor;
    using PowerSystemMonitoring.Web.ViewModels.CurrentSensor;
    using PowerSystemMonitoring.Web.ViewModels.PoweLine;

    public class PowerLinesController : Controller
    {
        private readonly IPowerLineService powerLineService;
        private readonly ICurrentSensorService currentSensorService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IConductorService conductorService;

        public PowerLinesController(
            IPowerLineService powerLineService,
            ICurrentSensorService currentSensorService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment webHostEnvironment,
            IConductorService conductorService)
        {
            this.powerLineService = powerLineService;
            this.currentSensorService = currentSensorService;
            this.userManager = userManager;
            this.webHostEnvironment = webHostEnvironment;
            this.conductorService = conductorService;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            var inputModel = new PowerLineInputModel();
            inputModel.Conductors = this.conductorService.GetAllAsSelectListItem();

            return this.View(inputModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Create(PowerLineInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var inputModel = new PowerLineInputModel();
                inputModel.Conductors = this.conductorService.GetAllAsSelectListItem();
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.User);

            await this.powerLineService.CreateAsync(input, user.Id, $"{this.webHostEnvironment.WebRootPath}/images");

            return this.RedirectToAction("All");
        }

        [Authorize]
        public IActionResult All()
        {
            var events = this.powerLineService.GetAll<PowerLineViewModel>();

            return this.View(events);
        }

        [Authorize]
        public IActionResult GetById(int id)
        {
            var inputModel = this.powerLineService.GetById<PowerLineViewModel>(id);

            inputModel.CurrentSensorsModels = this.currentSensorService.GetAllByPowerLineId<CurrentSensorViewModel>(id);

            return this.View(inputModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(int id)
        {
            var inputModel = this.powerLineService.GetById<PowerLineEditModel>(id);

            inputModel.CurrentSensorsModels = this.currentSensorService.GetAllByPowerLineId<CurrentSensorViewModel>(id);
            inputModel.Conductors = this.conductorService.GetAllAsSelectListItem();

            return this.View(inputModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, PowerLineEditModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.User);

            await this.powerLineService.UpdateAsync(id, input, user.Id, $"{this.webHostEnvironment.WebRootPath}/images");

            return this.RedirectToAction(nameof(this.All), new { id });
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult AddCurrentSensorToPowerLine(int id)
        {
            return this.RedirectToAction("AddToPowerLine", "CurrentSensors", new { id = id });
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await this.powerLineService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
