namespace PowerSystemMonitoring.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using PowerSystemMonitoring.Data.Common.Repositories;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;
    using PowerSystemMonitoring.Web.ViewModels.Area;

    public class AreaService : IAreaService
    {
        private readonly IDeletableEntityRepository<Area> areaRepository;
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };

        public AreaService(IDeletableEntityRepository<Area> areaRepository)
        {
            this.areaRepository = areaRepository;
        }

        public async Task CreateAsync(AreaInputModel input, string userId, string imagePath = null)
        {
            var area = new Area
            {
                AddedByUserId = userId,
                Name = input.Name,
            };

            Directory.CreateDirectory($"{imagePath}/areas/");

            foreach (var image in input.Images)
            {
                var extencion = Path.GetExtension(image.FileName).TrimStart('.');

                if (!this.allowedExtensions.Any(x => extencion.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extencion}");
                }

                var dbImage = new Image
                {
                    AddedByUserId = userId,
                    Extension = extencion,
                };

                area.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/areas/{dbImage.Id}.{extencion}";

                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);

                await image.CopyToAsync(fileStream);
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
    }
}
