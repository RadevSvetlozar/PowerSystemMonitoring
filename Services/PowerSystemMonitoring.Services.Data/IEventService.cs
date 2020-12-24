namespace PowerSystemMonitoring.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using PowerSystemMonitoring.Web.ViewModels.Area;
    using PowerSystemMonitoring.Web.ViewModels.Event;

    public interface IEventService
    {
        Task CreateAsync(EventInputModel input, string userId);

        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAllSorted<T>(string sortOrder);

        T GetById<T>(int id);

        Task UpdateAsync(int id, EditEventInputModel input);

        Task DeleteAsync(int id);

        Task ConfirmEventByIdAsync(int id);


    }
}
