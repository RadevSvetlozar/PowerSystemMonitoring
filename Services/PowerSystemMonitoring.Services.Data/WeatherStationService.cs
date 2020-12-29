namespace PowerSystemMonitoring.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.WebPages.Html;

    using Microsoft.AspNetCore.Http;
    using PowerSystemMonitoring.Data.Common.Models;
    using PowerSystemMonitoring.Data.Common.Repositories;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;
    using PowerSystemMonitoring.Web.ViewModels.WeatherStation;

    public class WeatherStationService : IWeatherStationService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<WeatherStation> stationRepository;
        private readonly IDeletableEntityRepository<Image> imageRepository;

        public WeatherStationService(
            IDeletableEntityRepository<WeatherStation> stationRepository,
            IDeletableEntityRepository<Image> imageRepository)
        {
            this.stationRepository = stationRepository;
            this.imageRepository = imageRepository;
        }

        public async Task CreateAsync(WeatherStationInputModel input, string userId, string imagePath = null)
        {
            var station = new WeatherStation
            {
                AddedByUserId = userId,
                City = input.City,
                InstalationDescription = input.InstalationDescription,
                IPAddress = input.IPAddress,
                IsActive = input.IsActive,
                Name = input.Name,
                Temperature = input.Temperature,
            };

            if (input.Image != null)
            {
                var image = await this.CreateImageAsync(input.Image, userId, imagePath);

                station.Image = image;
            }

            await this.stationRepository.AddAsync(station);
            await this.stationRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            var stations = this.stationRepository.All().To<T>().ToList();

            return stations;
        }

        public T GetById<T>(int id)
        {
            var station = this.stationRepository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();

            return station;
        }

        public async Task UpdateAsync(int id, WeatherStationEditModel input, string userId, string imagePath)
        {
            var station = this.stationRepository.All().FirstOrDefault(x => x.Id == id);

            var imageDb = this.imageRepository.All().Where(x => x.WeatherStationId == station.Id).FirstOrDefault();

            if (input.ImageFile != null)
            {
                var image = await this.CreateImageAsync(input.ImageFile, userId, imagePath);
                if (imageDb != null)
                {
                    imageDb.IsDeleted = true;
                }

                station.Image = image;
            }

            station.City = input.City;
            station.InstalationDescription = input.InstalationDescription;
            station.IPAddress = input.IPAddress;
            station.IsActive = input.IsActive;
            station.Name = input.Name;
            station.Temperature = input.Temperature;

            await this.stationRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var station = this.stationRepository.All().FirstOrDefault(x => x.Id == id);

            this.stationRepository.Delete(station);
            await this.stationRepository.SaveChangesAsync();
        }

        public IEnumerable<SelectListItem> GetAllAsSelectListItem()
        {
            var stations = this.stationRepository.All().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });

            return stations;
        }

        private async Task<Image> CreateImageAsync(IFormFile file, string userId, string imagePath)
        {
            Directory.CreateDirectory($"{imagePath}/weatherStations/");

            var extencion = Path.GetExtension(file.FileName).TrimStart('.');

            if (!this.allowedExtensions.Any(x => extencion.EndsWith(x)))
            {
                throw new Exception($"Invalid image extension {extencion}");
            }

            var dbImage = new Image
            {
                AddedByUserId = userId,
                Extension = extencion,
            };

            var physicalPath = $"{imagePath}/weatherStations/{dbImage.Id}.{extencion}";
            Stream fileStream = new FileStream(physicalPath, FileMode.Create);

            await file.CopyToAsync(fileStream);
            return dbImage;
        }
    }
}
