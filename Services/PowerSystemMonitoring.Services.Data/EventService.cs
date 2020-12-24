namespace PowerSystemMonitoring.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Tracing;
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

        public async Task ConfirmEventByIdAsync(int id)
        {
            var eventDb = this.eventRepository.All().FirstOrDefault(x => x.Id == id);

            eventDb.IsActive = false;

            await this.eventRepository.SaveChangesAsync();
        }

        public async Task CreateAsync(EventInputModel input, string userId)
        {
            var eventDb = new Event
            {
                Description = input.Description,
                Name = input.Name,
                IsActive = input.IsActive,
                AddedByUserId = userId,
            };

            await this.eventRepository.AddAsync(eventDb);
            await this.eventRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var eventDb = this.eventRepository.All().FirstOrDefault(x => x.Id == id);

            this.eventRepository.Delete(eventDb);
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

        public IEnumerable<T> GetAllSorted<T>(string sortOrder)
        {

            var events = this.eventRepository.All();
            switch (sortOrder)
            {
                case "currentSensor_asc":
                    events = events.OrderBy(x => x.CurrentSensor.Name);
                    break;
                case "currentSensor_desc":
                    events = events.OrderByDescending(x => x.CurrentSensor.Name);
                    break;
                case "date_asc":
                    events = events.OrderBy(x => x.CreatedOn);
                    break;
                case "date_desc":
                    events = events.OrderByDescending(x => x.CreatedOn);
                    break;
                case "isActive":
                    events = events.Where(x => x.IsActive);
                    break;
                case "isNotActive":
                    events = events.Where(x => !x.IsActive);
                    break;
                default:
                    events = events.OrderByDescending(s => s.CreatedOn);
                    break;
            }

            return events.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var eventDb = this.eventRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return eventDb;
        }

        public async Task UpdateAsync(int id, EditEventInputModel input)
        {
            var eventDb = this.eventRepository.All().FirstOrDefault(x => x.Id == id);

            eventDb.Name = input.Name;
            eventDb.Description = input.Description;
            eventDb.IsActive = input.IsActive;

            await this.eventRepository.SaveChangesAsync();
        }
    }
}
