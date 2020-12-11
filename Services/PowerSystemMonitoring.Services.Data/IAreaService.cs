namespace PowerSystemMonitoring.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using PowerSystemMonitoring.Web.ViewModels.Area;

    public interface IAreaService
    {
        Task CreateAsync(AreaInputModel input, string userId, string imagePath = null);

        IEnumerable<T> GetAll<T>();

        T GetById<T>(int id);
    }
}
