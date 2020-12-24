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
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Data;
    using PowerSystemMonitoring.Web.ViewModels.CurrentSensor;
    using PowerSystemMonitoring.Web.ViewModels.GeographicalCoordinates;

    public class CurrentSensorsController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ICurrentSensorService currentSensorService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IGeographicalCoordinatesService geographicalCoordinatesService;
        private readonly IWeatherStationService weatherStationService;

        public CurrentSensorsController(
            IWebHostEnvironment webHostEnvironment,
            ICurrentSensorService currentSensorService,
            UserManager<ApplicationUser> userManager,
            IGeographicalCoordinatesService geographicalCoordinatesService,
            IWeatherStationService weatherStationService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.currentSensorService = currentSensorService;
            this.userManager = userManager;
            this.geographicalCoordinatesService = geographicalCoordinatesService;
            this.weatherStationService = weatherStationService;
        }

        [Authorize]
        public IActionResult AddToPowerLine(int id)
        {
            var stations = this.weatherStationService.GetAllAsSelectListItem();

            var inputModel = new CurrentSensorInputModel();
            inputModel.WeatherStations = stations;

            this.TempData["powerLineId"] = id;
            return this.View(inputModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToPowerLine(CurrentSensorInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            };

            int powerLineId = (int)this.TempData["powerLineId"];

            var user = await this.userManager.GetUserAsync(this.User);

            await this.currentSensorService.CreateAsync(input, powerLineId, user.Id, $"{this.webHostEnvironment.WebRootPath}/images");

            this.TempData["Message"] = "CurrentSensors added successfully.";

            return this.RedirectToAction("Edit", "PowerLines", new { id = powerLineId });
        }

        [Authorize]
        public IActionResult All()
        {
            var conductors = this.currentSensorService.GetAll<CurrentSensorViewModel>();

            return this.View(conductors);
        }

        [Authorize]
        public IActionResult GetById(int id)
        {
            var inputModel = this.currentSensorService.GetById<CurrentSensorViewModel>(id);
            var coordinates = this.geographicalCoordinatesService.GetByCurrentSensorId<GeographicalCoordinatesViewModel>(id);
            inputModel.Latitude = coordinates.Latitude;
            inputModel.Longitude = coordinates.Longitude;

            return this.View(inputModel);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var stations = this.weatherStationService.GetAllAsSelectListItem();

            var inputModel = this.currentSensorService.GetById<EditCurrentSensor>(id);
            var coordinates = this.geographicalCoordinatesService.GetByCurrentSensorId<GeographicalCoordinatesViewModel>(id);
            inputModel.Latitude = coordinates.Latitude;
            inputModel.Longitude = coordinates.Longitude;
            inputModel.WeatherStations = stations;

            return this.View(inputModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCurrentSensor input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.User);

            await this.currentSensorService.UpdateAsync(id, input, user.Id, $"{this.webHostEnvironment.WebRootPath}/images");
            
            return this.RedirectToAction("Edit", "PowerLines", new { id = input.PowerLineId });
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            this.currentSensorService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
