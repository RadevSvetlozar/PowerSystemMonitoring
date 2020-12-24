namespace PowerSystemMonitoring.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using PowerSystemMonitoring.Data.Common.Repositories;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;
    using PowerSystemMonitoring.Web.ViewModels.Condutor;

    public class ConductorService : IConductorService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Conductor> conductorsRepository;
        private readonly IDeletableEntityRepository<Image> imageRepository;

        public ConductorService(
            IDeletableEntityRepository<Conductor> conductorsRepository,
            IDeletableEntityRepository<Image> imageRepository)
        {
            this.conductorsRepository = conductorsRepository;
            this.imageRepository = imageRepository;
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

            if (input.Image != null)
            {
                var image = await this.CreateImageAsync(input.Image, userId, imagePath);

                conductor.Image = image;
            }

            await this.conductorsRepository.AddAsync(conductor);
            await this.conductorsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var conductor = this.conductorsRepository.All().FirstOrDefault(x => x.Id == id);

            this.conductorsRepository.Delete(conductor);
            await this.conductorsRepository.SaveChangesAsync();

        }
        public IEnumerable<T> GetAll<T>()
        {
            var conductors = this.conductorsRepository.All()
                 .OrderByDescending(x => x.Id).To<T>()
                 .ToList();

            return conductors;
        }

        public T GetById<T>(int id)
        {
            var conductor = this.conductorsRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return conductor;
        }

        public async Task UpdateAsync(int id, ConductorEditModel input, string userId, string imagePath)
        {
            var conductor = this.conductorsRepository.All().FirstOrDefault(x => x.Id == id);

            var imageDb = this.imageRepository.All().Where(x => x.ConductorId == conductor.Id).FirstOrDefault();

            if (input.ImageFile != null)
            {
                var image = await this.CreateImageAsync(input.ImageFile, userId, imagePath);
                if (imageDb != null)
                {
                    imageDb.IsDeleted = true;
                }

                conductor.Image = image;
            }

            conductor.InnerDiameter = input.InnerDiameter;
            conductor.MaxCurrent = input.MaxCurrent;
            conductor.MaxTemperature = input.MaxTemperature;
            conductor.Name = input.Name;
            conductor.OuterDiameter = input.OuterDiameter;
            conductor.RTCoefficient = input.RTCoefficient;
            conductor.Section = input.Section;
            conductor.Weight = input.Weight;

            await this.conductorsRepository.SaveChangesAsync();
        }

        private async Task<Image> CreateImageAsync(IFormFile file, string userId, string imagePath)
        {
            Directory.CreateDirectory($"{imagePath}/conductors/");

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

            var physicalPath = $"{imagePath}/conductors/{dbImage.Id}.{extencion}";
            Stream fileStream = new FileStream(physicalPath, FileMode.Create);

            await file.CopyToAsync(fileStream);
            return dbImage;
        }
    }
}
