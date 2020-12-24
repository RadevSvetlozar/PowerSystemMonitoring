namespace PowerSystemMonitoring.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using PowerSystemMonitoring.Data.Common.Repositories;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Data;
    using PowerSystemMonitoring.Web.ViewModels.Area;

    public class AreasController : Controller
    {
        private readonly IAreaService areaService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<ApplicationUser> userManager;

        public AreasController(
            IAreaService areaService,
            IWebHostEnvironment webHostEnvironment,
            UserManager<ApplicationUser> userManager)
        {
            this.areaService = areaService;
            this.webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(AreaInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.User);

            await this.areaService.CreateAsync(input, user.Id, $"{this.webHostEnvironment.WebRootPath}/images");

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var areas = this.areaService.GetAll<AreaViewModel>();

            return this.View(areas);
        }

        public IActionResult GetById(int id)
        {
            var area = this.areaService.GetById<AreaViewModel>(id);

            return this.View(area);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var inputModel = this.areaService.GetById<AreaEditModel>(id);

            return this.View(inputModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, AreaEditModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.User);

            await this.areaService.UpdateAsync(id, input, user.Id, $"{this.webHostEnvironment.WebRootPath}/images");

            return this.RedirectToAction(nameof(this.All), new { id });
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            this.areaService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
