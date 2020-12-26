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
    using PowerSystemMonitoring.Web.ViewModels.WeatherStation;
    using Xunit;

    public class WeatherStationTests
    {
        [Fact]
        public async Task CreateCorrectllyWeatherStationModel()
        {
            var list = new List<WeatherStation>();
            var mockRepoStation = new Mock<IDeletableEntityRepository<WeatherStation>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoStation.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoStation.Setup(x => x.AddAsync(It.IsAny<WeatherStation>())).Callback((WeatherStation weatherStation) => list.Add(weatherStation));

            var service = new WeatherStationService(mockRepoStation.Object, mockRepoImage.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new WeatherStationInputModel
                {

                    Name = "test",
                    Image = file,
                };

                await service.CreateAsync(inputModel, "23");
                await service.CreateAsync(inputModel, "213");

                Assert.Equal(2, list.Count);
            }
        }

        [Fact]
        public async Task DeleteCorrectllyWeatherStationModel()
        {
            var list = new List<WeatherStation>();
            var mockRepoStation = new Mock<IDeletableEntityRepository<WeatherStation>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoStation.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoStation.Setup(x => x.Delete(It.IsAny<WeatherStation>())).Callback((WeatherStation weatherStation) => list.Remove(weatherStation));

            var service = new WeatherStationService(mockRepoStation.Object, mockRepoImage.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new WeatherStationInputModel
                {

                    Name = "test",
                    Image = file,
                };

                await service.CreateAsync(inputModel, "23");
                await service.CreateAsync(inputModel, "213");

                await service.DeleteAsync(0);

                Assert.Equal(0, list.Count);
            }
        }

        [Fact]
        public void GetAllWorkCorrecllyWeatherStationModel()
        {
            this.TestGetAllWorkCorrectllyWeatherStationModel<WeatherStationViewModel>();
        }

        public async Task TestGetAllWorkCorrectllyWeatherStationModel<T>()
        {
            var list = new List<WeatherStation>();
            var mockRepoStation = new Mock<IDeletableEntityRepository<WeatherStation>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoStation.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoStation.Setup(x => x.AddAsync(It.IsAny<WeatherStation>())).Callback((WeatherStation weatherStation) => list.Add(weatherStation));

            var service = new WeatherStationService(mockRepoStation.Object, mockRepoImage.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new WeatherStationInputModel
                {

                    Name = "test",
                    Image = file,
                };

                await service.CreateAsync(inputModel, "23");
                await service.CreateAsync(inputModel, "213");

                var count = service.GetAll<T>().Count();

                Assert.Equal(2, count);
            }
        }

        [Fact]
        public void GetByIdWorkCorrecllyWeatherStationModel()
        {
            var model = this.TestGetByIdWorkCorrectllyWeatherStationModel<WeatherStationViewModel>();
            Assert.NotNull(model);
        }

        public async Task<T> TestGetByIdWorkCorrectllyWeatherStationModel<T>()
        {
            var list = new List<WeatherStation>();
            var mockRepoStation = new Mock<IDeletableEntityRepository<WeatherStation>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoStation.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoStation.Setup(x => x.AddAsync(It.IsAny<WeatherStation>())).Callback((WeatherStation weatherStation) => list.Add(weatherStation));

            var service = new WeatherStationService(mockRepoStation.Object, mockRepoImage.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new WeatherStationInputModel
                {

                    Name = "test",
                    Image = file,
                };

                await service.CreateAsync(inputModel, "23");
                await service.CreateAsync(inputModel, "213");

                var model = service.GetById<T>(0);

                return model;
            }
        }
    }
}
