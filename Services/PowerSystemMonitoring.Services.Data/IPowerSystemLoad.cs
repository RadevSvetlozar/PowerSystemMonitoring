namespace PowerSystemMonitoring.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PowerSystemMonitoring.Web.ViewModels.PowerSystemLoad;

    public interface IPowerSystemLoad
    {
        PowerSystemLoadViewModel GetLoad();
    }
}
