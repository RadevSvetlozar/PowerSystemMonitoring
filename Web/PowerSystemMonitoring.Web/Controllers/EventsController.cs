namespace PowerSystemMonitoring.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using PowerSystemMonitoring.Common;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Data;
    using PowerSystemMonitoring.Web.ViewModels;
    using PowerSystemMonitoring.Web.ViewModels.Event;

    public class EventsController : Controller
    {
        private readonly IEventService eventService;
        private readonly UserManager<ApplicationUser> userManager;

        public EventsController(
            IEventService eventService,
            UserManager<ApplicationUser> userManager)
        {
            this.eventService = eventService;
            this.userManager = userManager;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Create(EventInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.eventService.CreateAsync(input, user.Id);

            return this.RedirectToAction("All");
        }

        [Authorize]
        public IActionResult All()
        {
            var events = this.eventService.GetAll<EventViewModel>();

            return this.View(events);
        }

        [Authorize]
        public IActionResult AllSorted(string sortOrder = null)
        {
            var events = this.eventService.GetAllSorted<EventViewModel>(sortOrder);

            return this.View(events);
        }

        [Authorize]
        public IActionResult GetById(int id)
        {
            var currentEvent = this.eventService.GetById<EventViewModel>(id);

            return this.View(currentEvent);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(int id)
        {
            var inputModel = this.eventService.GetById<EditEventInputModel>(id);

            return this.View(inputModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditEventInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.eventService.UpdateAsync(id, input);

            return this.RedirectToAction(nameof(this.All), new { id });
        }

        [Authorize]
        public async Task<IActionResult> ConfirmAsync(int id)
        {
           await this.eventService.ConfirmEventByIdAsync(id);

           return this.RedirectToAction(nameof(this.AllSorted));
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await this.eventService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
