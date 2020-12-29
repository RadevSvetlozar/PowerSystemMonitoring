namespace PowerSystemMonitoring.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using PowerSystemMonitoring.Data.Common.Models;
    using PowerSystemMonitoring.Data.Common.Repositories;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;

    public class RealTimeCurrentSensorService : IRealTimeCurrentSensorService
    {
        private readonly IDeletableEntityRepository<RealTimeValues> realTimeRepository;

        public RealTimeCurrentSensorService(IDeletableEntityRepository<RealTimeValues> realTimeRepository)
        {
            this.realTimeRepository = realTimeRepository;
        }

        public T GetLast<T>()
        {
            var model = this.realTimeRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .To<T>()
                .FirstOrDefault();

            return model;
        }
    }
}
