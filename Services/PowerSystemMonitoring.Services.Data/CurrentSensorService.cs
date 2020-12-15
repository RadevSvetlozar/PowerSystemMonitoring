namespace PowerSystemMonitoring.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using PowerSystemMonitoring.Data.Common.Repositories;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;
    using PowerSystemMonitoring.Web.ViewModels.Condutor;
    using PowerSystemMonitoring.Web.ViewModels.CurrentSensor;
    using System.Web.WebPages.Html;

    public class CurrentSensorService : ICurrentSensorService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<CurrentSensor> currentSensorRepository;
        private readonly IDeletableEntityRepository<Image> imageRepository;
        private readonly IDeletableEntityRepository<GeographicalCoordinates> coordinatesRepository;

        public CurrentSensorService(
            IDeletableEntityRepository<CurrentSensor> currentSensorRepository,
            IDeletableEntityRepository<Image> imageRepository,
            IDeletableEntityRepository<GeographicalCoordinates> coordinatesRepository)
        {
            this.currentSensorRepository = currentSensorRepository;
            this.imageRepository = imageRepository;
            this.coordinatesRepository = coordinatesRepository;
        }

        public async Task CreateAsync(CurrentSensorInputModel input, int powerLineId, string userId, string imagePath = null)
        {
            var currentSensor = new CurrentSensor
            {
                ConnectionPassword = input.ConnectionPassword,
                DistancePole = input.DistancePole,
                InstallationHeight = input.InstallationHeight,
                Orientation = input.Orientation,
                Name = input.Name,
                IPAddress = input.IPAddress,
                IsActive = input.IsActive,
                Model = input.Model,
                PhoneNumber = input.PhoneNumber,
                AddedByUserId = userId,
                PowerLineId = powerLineId,
            };

            if (input.Image != null)
            {
                var image = await this.CreateImageAsync(input.Image, userId, imagePath);

                currentSensor.Image = image;
            }

            if (input.Latitude != null && input.Longitude != null)
            {
                var coordinates = new GeographicalCoordinates
                {
                    Latitude = input.Latitude,
                    Longitude = input.Longitude,
                };
                await this.coordinatesRepository.AddAsync(coordinates);
                currentSensor.GeographicalCoordinates = coordinates;
            }

            await this.currentSensorRepository.AddAsync(currentSensor);
            await this.currentSensorRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            var currentSensors = this.currentSensorRepository.All()
            .To<T>()
            .ToList();

            return currentSensors;
        }

        public T GetById<T>(int id)
        {
            var currentSensor = this.currentSensorRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return currentSensor;
        }

        public IEnumerable<SelectListItem> GetAllSensorsAsSelectListItems()
        {
            var list = this.currentSensorRepository.All().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            }).ToList();

            return list;
        }
        public IEnumerable<T> GetAllByPowerLineId<T>(int id)
        {
            var sensors = this.currentSensorRepository.All()
                .Where(x => x.PowerLineId == id)
                .To<T>()
                .ToList();

            return sensors;
        }

        public async Task UpdateAsync(int id, EditCurrentSensor input, string userId, string imagePath)
        {
            var currentSensor = this.currentSensorRepository.All().FirstOrDefault(x => x.Id == id);

            var imageDb = this.imageRepository.All().Where(x => x.CurrentSensorId == currentSensor.Id).FirstOrDefault();

            var coordinatesDb = this.coordinatesRepository.All().FirstOrDefault(x => x.CurrentSensorId == id);

            if (input.ImageFile != null)
            {
                var image = await this.CreateImageAsync(input.ImageFile, userId, imagePath);
                if (imageDb != null)
                {
                    imageDb.IsDeleted = true;
                }

                currentSensor.Image = image;
            }

            if (currentSensor.GeographicalCoordinates != null)
            {
               var coordinates = new GeographicalCoordinates
                {
                    AddedByUserId = userId,
                    Latitude = input.Latitude,
                    Longitude = input.Longitude,
                };
               if (coordinatesDb != null)
                {
                    coordinatesDb.IsDeleted = true;
                }

               currentSensor.GeographicalCoordinates = coordinates;
               await this.coordinatesRepository.AddAsync(coordinates);
            }

            currentSensor.GeographicalCoordinates.Longitude = input.Longitude;
            currentSensor.GeographicalCoordinates.Latitude = input.Latitude;
            currentSensor.InstallationHeight = input.InstallationHeight;
            currentSensor.IPAddress = input.IPAddress;
            currentSensor.IsActive = input.IsActive;
            currentSensor.Model = input.Model;
            currentSensor.Name = input.Name;
            currentSensor.Orientation = input.Orientation;
            currentSensor.PhoneNumber = input.PhoneNumber;
            currentSensor.ConnectionPassword = input.ConnectionPassword;

            await this.currentSensorRepository.SaveChangesAsync();
        }

        private async Task<Image> CreateImageAsync(IFormFile file, string userId, string imagePath)
        {
            Directory.CreateDirectory($"{imagePath}/currentSensors/");

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

            var physicalPath = $"{imagePath}/currentSensors/{dbImage.Id}.{extencion}";
            Stream fileStream = new FileStream(physicalPath, FileMode.Create);

            await file.CopyToAsync(fileStream);
            return dbImage;
        }

    }
}
