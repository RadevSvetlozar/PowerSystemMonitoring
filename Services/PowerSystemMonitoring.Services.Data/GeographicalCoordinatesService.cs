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
    using PowerSystemMonitoring.Web.ViewModels.GeographicalCoordinates;

    public class GeographicalCoordinatesService : IGeographicalCoordinatesService
    {
        private readonly IDeletableEntityRepository<GeographicalCoordinates> geographicalCoordinatesReposotory;

        public GeographicalCoordinatesService(IDeletableEntityRepository<GeographicalCoordinates> geographicalCoordinatesReposotory)
        {
            this.geographicalCoordinatesReposotory = geographicalCoordinatesReposotory;
        }

        public async Task CreateAsync(GeographicalCoordinatesInputModel input, string userId)
        {
            var coordinates = new GeographicalCoordinates
            {
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                AddedByUserId = input.AddedByUserUsername,
            };

            await this.geographicalCoordinatesReposotory.AddAsync(coordinates);
            await this.geographicalCoordinatesReposotory.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var coordinates = this.geographicalCoordinatesReposotory.All().FirstOrDefault(x => x.Id == id);

            this.geographicalCoordinatesReposotory.Delete(coordinates);
            await this.geographicalCoordinatesReposotory.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.geographicalCoordinatesReposotory.All()
                .To<T>()
                .ToList();
        }

        public T GetByCurrentSensorId<T>(int id)
        {
            var coornaties = this.geographicalCoordinatesReposotory.All()
                .Where(x => x.CurrentSensorId == id)
                .To<T>()
                .FirstOrDefault();

            return coornaties;
        }

        public T GetById<T>(int id)
        {
            return this.geographicalCoordinatesReposotory.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();
        }

        public async Task UpdateAsync(int id, EditGeographicalCoordinatesModel input)
        {
            var coordinates = this.geographicalCoordinatesReposotory.All().FirstOrDefault(x => x.Id == id);

            coordinates.Latitude = input.Latitude;
            coordinates.Longitude = input.Longitude;

            await this.geographicalCoordinatesReposotory.SaveChangesAsync();
        }
    }
}
