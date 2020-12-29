namespace PowerSystemMonitoring.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Internal;
    using Moq;
    using PowerSystemMonitoring.Data.Common.Repositories;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Services.Mapping;
    using PowerSystemMonitoring.Web.ViewModels.Area;
    using Xunit;

    public class AreaTests
    {
        [Fact]
        public async Task CreateCorrectllyAreaModel()
        {
            var list = new List<Area>();
            var mockRepoArea = new Mock<IDeletableEntityRepository<Area>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoArea.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoArea.Setup(x => x.Delete(It.IsAny<Area>())).Callback((Area area) => list.Remove(area));

            var service = new AreaService(mockRepoArea.Object, mockRepoImage.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new AreaInputModel
                {
                    Name = "test",
                    Image = file,
                };

                await service.CreateAsync(inputModel, "23");
                await service.CreateAsync(inputModel, "213");

                service.DeleteAsync(0);

                Assert.Equal(0, list.Count);
            }
        }

        [Fact]
        public async Task DeleteCorrectllyAreaModel()
        {
            var list = new List<Area>();
            var mockRepoArea = new Mock<IDeletableEntityRepository<Area>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoArea.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoArea.Setup(x => x.AddAsync(It.IsAny<Area>())).Callback((Area area) => list.Add(area));

            var service = new AreaService(mockRepoArea.Object, mockRepoImage.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new AreaInputModel
                {
                    Name = "test",
                    Image = file,
                };

                await service.CreateAsync(inputModel, "23");
                await service.CreateAsync(inputModel, "13");

                Assert.Equal(2, list.Count);
            }
        }

        [Fact]
        public void GetAllWorkCorrecllyAreaModel()
        {
            this.TestGetAllWorkCorrectllyAreaModel<AreaViewModel>();
        }

        public async Task TestGetAllWorkCorrectllyAreaModel<T>()
        {
            var list = new List<Area>();
            var mockRepoArea = new Mock<IDeletableEntityRepository<Area>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoArea.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoArea.Setup(x => x.AddAsync(It.IsAny<Area>())).Callback((Area area) => list.Add(area));

            var viewModelList = new List<AreaViewModel>();

            var service = new AreaService(mockRepoArea.Object, mockRepoImage.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new AreaInputModel
                {
                    Name = "test",
                    Image = file,
                };

                await service.CreateAsync(inputModel, "23");
                await service.CreateAsync(inputModel, "13");

                var count = service.GetAll<T>().ToList<T>().Count();

                Assert.Equal(2, count);
            }
        }

        [Fact]
        public void GetByIdWorkCorrecllyAreaModel()
        {
            var model = this.TestGetByIdWorkCorrectllyAreaModel<AreaViewModel>();
            Assert.NotNull(model);
        }

        public async Task<T> TestGetByIdWorkCorrectllyAreaModel<T>()
        {
            var list = new List<Area>();
            var mockRepoArea = new Mock<IDeletableEntityRepository<Area>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoArea.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoArea.Setup(x => x.AddAsync(It.IsAny<Area>())).Callback((Area area) => list.Add(area));

            var viewModelList = new List<AreaViewModel>();

            var service = new AreaService(mockRepoArea.Object, mockRepoImage.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new AreaInputModel
                {
                    Name = "test",
                    Image = file,
                };

                await service.CreateAsync(inputModel, "23");

                var model = service.GetById<T>(0);

                return model;
            }
        }
    }
}
