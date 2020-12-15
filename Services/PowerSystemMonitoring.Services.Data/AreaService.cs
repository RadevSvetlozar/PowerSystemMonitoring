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
    using PowerSystemMonitoring.Web.ViewModels.Area;
    using PowerSystemMonitoring.Web.ViewModels.Condutor;

    public class AreaService : IAreaService
    {
        private readonly IDeletableEntityRepository<Area> areaRepository;
        private readonly IDeletableEntityRepository<Image> imageRepository;
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };

        public AreaService(
            IDeletableEntityRepository<Area> areaRepository,
            IDeletableEntityRepository<Image> imageRepository)
        {
            this.areaRepository = areaRepository;
            this.imageRepository = imageRepository;
        }

        public async Task CreateAsync(AreaInputModel input, string userId, string imagePath = null)
        {
            var area = new Area
            {
                AddedByUserId = userId,
                Name = input.Name,
            };

            if (input.Image != null)
            {
                var image = await this.CreateImageAsync(input.Image, userId, imagePath);

                area.Image = image;
            }

            await this.areaRepository.AddAsync(area);
            await this.areaRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.areaRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id).To<T>()
                .ToList();
        }

        public T GetById<T>(int id)
        {
            var area = this.areaRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return area;
        }

        public async Task UpdateAsync(int id, AreaEditModel input, string userId, string imagePath)
        {
            var area = this.areaRepository.All().FirstOrDefault(x => x.Id == id);

            var imageDb = this.imageRepository.All().Where(x => x.AreaId == area.Id).FirstOrDefault();
            if (input.ImageFile != null)
            {
                var image = await this.CreateImageAsync(input.ImageFile, userId, imagePath);

                if (imageDb != null)
                {
                    imageDb.IsDeleted = true;
                }

                area.Image = image;
            }

            area.Name = input.Name;

            await this.areaRepository.SaveChangesAsync();
        }

        private async Task<Image> CreateImageAsync(IFormFile file, string userId, string imagePath)
        {
            Directory.CreateDirectory($"{imagePath}/areas/");

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

            var physicalPath = $"{imagePath}/areas/{dbImage.Id}.{extencion}";
            Stream fileStream = new FileStream(physicalPath, FileMode.Create);

            await file.CopyToAsync(fileStream);
            return dbImage;
        }
    }
}
