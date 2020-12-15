namespace PowerSystemMonitoring.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using PowerSystemMonitoring.Web.ViewModels.GeographicalCoordinates;

    public interface IGeographicalCoordinatesService
    {
        Task CreateAsync(GeographicalCoordinatesInputModel input, string userId);

        IEnumerable<T> GetAll<T>();

        T GetById<T>(int id);

        Task UpdateAsync(int id, EditGeographicalCoordinatesModel input);

        T GetByCurrentSensorId<T>(int id);
    }
}
