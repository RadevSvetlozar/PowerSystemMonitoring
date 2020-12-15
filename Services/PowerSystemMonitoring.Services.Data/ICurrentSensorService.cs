namespace PowerSystemMonitoring.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.WebPages.Html;
    using PowerSystemMonitoring.Web.ViewModels.CurrentSensor;

    public interface ICurrentSensorService
    {
        Task CreateAsync(CurrentSensorInputModel input, int powerLineId, string userId, string imagePath = null);

        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAllByPowerLineId<T>(int id);

        T GetById<T>(int id);

        Task UpdateAsync(int id, EditCurrentSensor input, string userId, string imagePath);

        IEnumerable<SelectListItem> GetAllSensorsAsSelectListItems();
    }
}
