namespace PowerSystemMonitoring.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IRealTimeCurrentSensorService
    {
        T GetLast<T>();
    }
}
