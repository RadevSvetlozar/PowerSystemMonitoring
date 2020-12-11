﻿namespace PowerSystemMonitoring.Web.Controllers
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

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
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

        public IActionResult GetById(int id)
        {
            var currentEvent = this.eventService.GetById<EventViewModel>(id);

            return this.View(currentEvent);
        }
    }
}
