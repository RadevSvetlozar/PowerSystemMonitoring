namespace PowerSystemMonitoring.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using PowerSystemMonitoring.Data.Common.Repositories;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;
    using PowerSystemMonitoring.Web.ViewModels.Area;
    using PowerSystemMonitoring.Web.ViewModels.Event;

    public class EventService : IEventService
    {
        private readonly IDeletableEntityRepository<Event> eventRepository;

        public EventService(IDeletableEntityRepository<Event> eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public async Task CreateAsync(EventInputModel input, string userId)
        {
            var eventDb = new Event
            {
                Description = input.Description,
                Name = input.Name,
                IsActive = input.IsActive,
            };

            await this.eventRepository.AddAsync(eventDb);
            await this.eventRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            var events = this.eventRepository.All()
                .OrderByDescending(x => x.Id)
                .To<T>()
                .ToList();

            return events;
        }

        public T GetById<T>(int id)
        {
            var eventDb = this.eventRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return eventDb;
        }
    }
}
