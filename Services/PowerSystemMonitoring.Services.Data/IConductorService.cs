﻿namespace PowerSystemMonitoring.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.WebPages.Html;

    using PowerSystemMonitoring.Web.ViewModels.Condutor;

    public interface IConductorService
    {
        Task CreateAsync(ConductorInputModel input, string userId, string imagePath = null);

        IEnumerable<T> GetAll<T>();

        IEnumerable<SelectListItem> GetAllAsSelectListItem();

        T GetById<T>(int id);

        Task UpdateAsync(int id, ConductorEditModel input, string userId, string imagePath);

        Task DeleteAsync(int id);
    }
}
