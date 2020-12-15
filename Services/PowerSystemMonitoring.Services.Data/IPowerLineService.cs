namespace PowerSystemMonitoring.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using PowerSystemMonitoring.Web.ViewModels.PoweLine;

    public interface IPowerLineService
    {
        Task CreateAsync(PowerLineInputModel input, string userId, string imagePath);

        IEnumerable<T> GetAll<T>();

        T GetById<T>(int id);

        Task UpdateAsync(int id, PowerLineEditModel input, string userId, string imagePath);
    }
}
