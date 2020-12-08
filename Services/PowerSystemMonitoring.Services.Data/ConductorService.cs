namespace PowerSystemMonitoring.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using PowerSystemMonitoring.Data.Common.Repositories;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;
    using PowerSystemMonitoring.Web.ViewModels.Condutor;

    public class ConductorService : IConductorService
    {
        private readonly IDeletableEntityRepository<Conductor> conductorsRepository;

        public ConductorService(IDeletableEntityRepository<Conductor> conductorsRepository)
        {
            this.conductorsRepository = conductorsRepository;
        }

        public async Task CreateAsync(ConductorInputModel input, string userId, string imagePath = null)
        {
            var conductor = new Conductor
            {
                AddedByUserId = userId,
                CoefficientOfThermalExpansion = input.CoefficientOfThermalExpansion,
                Current = input.Current,
                Elasticity = input.Elasticity,
                InnerDiameter = input.InnerDiameter,
                MaxCurrent = input.MaxCurrent,
                ConductorPerPhase = input.ConductorPerPhase,
                OuterDiameter = input.OuterDiameter,
                MaxTemperature = input.MaxTemperature,
                Name = input.Name,
                RTCoefficient = input.RTCoefficient,
                Section = input.Section,
                Weight = input.Weight,
            };

            await this.conductorsRepository.AddAsync(conductor);
            await this.conductorsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
           return this.conductorsRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id).To<T>()
                .ToList();
        }

        public T GetById<T>(int id)
        {
            var conductor = this.conductorsRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return conductor;
        }
    }
}
