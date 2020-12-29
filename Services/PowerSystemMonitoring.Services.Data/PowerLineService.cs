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
    using PowerSystemMonitoring.Web.ViewModels.PoweLine;

    public class PowerLineService : IPowerLineService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<PowerLine> powerLineRepository;
        private readonly IDeletableEntityRepository<CurrentSensor> currentSensorsRepository;
        private readonly IDeletableEntityRepository<Image> imageRepository;

        public PowerLineService(
            IDeletableEntityRepository<PowerLine> powerLineRepository,
            IDeletableEntityRepository<CurrentSensor> currentSensorsRepository,
            IDeletableEntityRepository<Image> imageRepository)
        {
            this.powerLineRepository = powerLineRepository;
            this.currentSensorsRepository = currentSensorsRepository;
            this.imageRepository = imageRepository;
        }

        public async Task CreateAsync(PowerLineInputModel input, string userId, string imagePath = null)
        {
            var powerLine = new PowerLine
            {
                Name = input.Name,
                AddedByUserId = userId,
                Length = input.Length,
                Voltage = input.Voltage,
            };
            if (input.Image != null)
            {
                var image = await this.CreateImageAsync(input.Image, userId, imagePath);

                powerLine.Image = image;
            }

            powerLine.ConductorId = input.ConductorId;

            await this.powerLineRepository.AddAsync(powerLine);
            await this.powerLineRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            var events = this.powerLineRepository.All()
                .OrderByDescending(x => x.Id)
                .To<T>()
                .ToList();

            return events;
        }

        public T GetById<T>(int id)
        {
            var eventDb = this.powerLineRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return eventDb;
        }

        public async Task UpdateAsync(int id, PowerLineEditModel input, string userId, string imagePath)
        {
            var line = this.powerLineRepository.All().FirstOrDefault(x => x.Id == id);

            var imageDb = this.imageRepository.All().Where(x => x.PowerLineId == line.Id).FirstOrDefault();

            if (input.ImageFile != null)
            {
                var image = await this.CreateImageAsync(input.ImageFile, userId, imagePath);
                if (imageDb != null)
                {
                    imageDb.IsDeleted = true;
                }

                line.Image = image;
            }

            line.Length = input.Length;
            line.Name = input.Name;
            line.Voltage = input.Voltage;
            line.ConductorId = input.ConductorId;

            await this.powerLineRepository.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var line = this.powerLineRepository.All().FirstOrDefault(x => x.Id == id);

            this.powerLineRepository.Delete(line);
            await this.powerLineRepository.SaveChangesAsync();
        }

        private async Task<Image> CreateImageAsync(IFormFile file, string userId, string imagePath)
        {
            Directory.CreateDirectory($"{imagePath}/powerLines/");

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

            var physicalPath = $"{imagePath}/powerLines/{dbImage.Id}.{extencion}";
            Stream fileStream = new FileStream(physicalPath, FileMode.Create);

            await file.CopyToAsync(fileStream);
            return dbImage;
        }
    }
}
