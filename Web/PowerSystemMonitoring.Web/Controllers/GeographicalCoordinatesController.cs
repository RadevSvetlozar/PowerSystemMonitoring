namespace PowerSystemMonitoring.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Data;
    using PowerSystemMonitoring.Web.ViewModels.GeographicalCoordinates;

    public class GeographicalCoordinatesController : Controller
    {
        private readonly IGeographicalCoordinatesService geographicalCoordinatesService;
        private readonly UserManager<ApplicationUser> userManager;

        public GeographicalCoordinatesController(
            IGeographicalCoordinatesService geographicalCoordinatesService,
            UserManager<ApplicationUser> userManager)
        {
            this.geographicalCoordinatesService = geographicalCoordinatesService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(GeographicalCoordinatesInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.geographicalCoordinatesService.CreateAsync(input, user.Id);

            return this.RedirectToAction("All");
        }

        [Authorize]
        public IActionResult All()
        {
            var events = this.geographicalCoordinatesService.GetAll<GeographicalCoordinatesViewModel>();

            return this.View(events);
        }

        public IActionResult GetById(int id)
        {
            var currentEvent = this.geographicalCoordinatesService.GetById<GeographicalCoordinatesViewModel>(id);

            return this.View(currentEvent);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var inputModel = this.geographicalCoordinatesService.GetById<EditGeographicalCoordinatesModel>(id);

            return this.View(inputModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditGeographicalCoordinatesModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.geographicalCoordinatesService.UpdateAsync(id, input);

            return this.RedirectToAction(nameof(this.All), new { id });
        }
    }
}
