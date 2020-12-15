namespace PowerSystemMonitoring.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using PowerSystemMonitoring.Web.ViewModels.WeatherStation;

    public interface IWeatherStationService
    {
        Task CreateAsync(WeatherStationInputModel input, string userId, string imagePath);

        IEnumerable<T> GetAll<T>();

        T GetById<T>(int id);

        Task UpdateAsync(int id, WeatherStationEditModel input, string userId, string imagePath);
    }
}
