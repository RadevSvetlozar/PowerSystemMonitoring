namespace PowerSystemMonitoring.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http.Internal;
    using Moq;
    using PowerSystemMonitoring.Data.Common.Repositories;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Web.ViewModels.GeographicalCoordinates;
    using Xunit;

    public class GeographicalCoordinatesTests
    {
        [Fact]
        public async Task CreateCorrectllyEventModel()
        {
            var list = new List<GeographicalCoordinates>();
            var mockRepoGeoCoordinates = new Mock<IDeletableEntityRepository<GeographicalCoordinates>>();

            mockRepoGeoCoordinates.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoGeoCoordinates.Setup(x => x.AddAsync(It.IsAny<GeographicalCoordinates>())).Callback((GeographicalCoordinates coordinates) => list.Add(coordinates));

            var service = new GeographicalCoordinatesService(mockRepoGeoCoordinates.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new GeographicalCoordinatesInputModel
                {
                    Latitude = "test",
                    Longitude = "test1",
                };

                await service.CreateAsync(inputModel, "23");
                await service.CreateAsync(inputModel, "213");

                Assert.Equal(2, list.Count);
            }
        }

        [Fact]
        public async Task DeleteCorrectllyEventModel()
        {
            var list = new List<GeographicalCoordinates>();
            var mockRepoGeoCoordinates = new Mock<IDeletableEntityRepository<GeographicalCoordinates>>();

            mockRepoGeoCoordinates.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoGeoCoordinates.Setup(x => x.Delete(It.IsAny<GeographicalCoordinates>())).Callback((GeographicalCoordinates coordinates) => list.Remove(coordinates));

            var service = new GeographicalCoordinatesService(mockRepoGeoCoordinates.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new GeographicalCoordinatesInputModel
                {
                    Latitude = "test",
                    Longitude = "test1",
                };

                await service.CreateAsync(inputModel, "23");
                await service.CreateAsync(inputModel, "213");
                await service.DeleteAsync(0);

                Assert.Equal(0, list.Count);
            }
        }

        [Fact]
        public void GetAllWorkCorrecllyGeographicalCoordinatesModel()
        {
            this.TestGetAllWorkCorrectllyGeographicalCoordinatesModel<GeographicalCoordinatesViewModel>();
        }

        public async Task TestGetAllWorkCorrectllyGeographicalCoordinatesModel<T>()
        {
            var list = new List<GeographicalCoordinates>();
            var mockRepoGeoCoordinates = new Mock<IDeletableEntityRepository<GeographicalCoordinates>>();

            mockRepoGeoCoordinates.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoGeoCoordinates.Setup(x => x.AddAsync(It.IsAny<GeographicalCoordinates>())).Callback((GeographicalCoordinates coordinates) => list.Add(coordinates));

            var service = new GeographicalCoordinatesService(mockRepoGeoCoordinates.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new GeographicalCoordinatesInputModel
                {
                    Latitude = "test",
                    Longitude = "test1",
                };

                await service.CreateAsync(inputModel, "23");
                await service.CreateAsync(inputModel, "213");

                var count = service.GetAll<T>().Count();

                Assert.Equal(2, count);
            }
        }

        [Fact]
        public void GetByIdWorkCorrecllyGeographicalCoordinatesModel()
        {
            var model = this.TestGetByIdWorkCorrectllyGeographicalCoordinatesModel<GeographicalCoordinatesViewModel>();
            Assert.NotNull(model);
        }

        public async Task<T> TestGetByIdWorkCorrectllyGeographicalCoordinatesModel<T>()
        {
            var list = new List<GeographicalCoordinates>();
            var mockRepoGeoCoordinates = new Mock<IDeletableEntityRepository<GeographicalCoordinates>>();

            mockRepoGeoCoordinates.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoGeoCoordinates.Setup(x => x.AddAsync(It.IsAny<GeographicalCoordinates>())).Callback((GeographicalCoordinates coordinates) => list.Add(coordinates));

            var service = new GeographicalCoordinatesService(mockRepoGeoCoordinates.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new GeographicalCoordinatesInputModel
                {
                    Latitude = "test",
                    Longitude = "test1",
                };

                await service.CreateAsync(inputModel, "23");
                await service.CreateAsync(inputModel, "213");

                var model = service.GetById<T>(0);

                return model;
            }
        }
    }
}
