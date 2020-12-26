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
    using PowerSystemMonitoring.Web.ViewModels.Condutor;
    using PowerSystemMonitoring.Web.ViewModels.CurrentSensor;
    using PowerSystemMonitoring.Web.ViewModels.GeographicalCoordinates;
    using Xunit;

    public class CurrentSensorTests
    {
        [Fact]
        public async Task CreateCorrectllyCurrentSensorModel()
        {
            var list = new List<CurrentSensor>();
            var mockRepoCurrentSensor = new Mock<IDeletableEntityRepository<CurrentSensor>>(); var mockRepoCoordinates = new Mock<IDeletableEntityRepository<GeographicalCoordinates>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoCurrentSensor.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoCurrentSensor.Setup(x => x.AddAsync(It.IsAny<CurrentSensor>())).Callback((CurrentSensor currentSensor) => list.Add(currentSensor));

            var service = new CurrentSensorService(mockRepoCurrentSensor.Object, mockRepoImage.Object, mockRepoCoordinates.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new CurrentSensorInputModel
                {

                    Name = "test",
                    Image = file,
                };

                await service.CreateAsync(inputModel, 2, "23");
                await service.CreateAsync(inputModel, 3, "213");

                Assert.Equal(2, list.Count);
            }
        }

        [Fact]
        public async Task DeleteCorrectllyCurrentSensorModel()
        {
            var list = new List<CurrentSensor>();
            var mockRepoCurrentSensor = new Mock<IDeletableEntityRepository<CurrentSensor>>(); var mockRepoCoordinates = new Mock<IDeletableEntityRepository<GeographicalCoordinates>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoCurrentSensor.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoCurrentSensor.Setup(x => x.Delete(It.IsAny<CurrentSensor>())).Callback((CurrentSensor currentSensor) => list.Remove(currentSensor));

            var service = new CurrentSensorService(mockRepoCurrentSensor.Object, mockRepoImage.Object, mockRepoCoordinates.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new CurrentSensorInputModel
                {

                    Name = "test",
                    Image = file,
                };

                await service.CreateAsync(inputModel, 2, "23");
                await service.CreateAsync(inputModel, 3, "213");

                await service.DeleteAsync(0);

                Assert.Equal(0, list.Count);
            }
        }

        [Fact]
        public void GetAllWorkCorrecllyCurrentSensorModel()
        {
            this.TestGetAllWorkCorrectllyCurrentSensorModel<CurrentSensorViewModel>();
        }

        public async Task TestGetAllWorkCorrectllyCurrentSensorModel<T>()
        {
            var list = new List<CurrentSensor>();
            var mockRepoCurrentSensor = new Mock<IDeletableEntityRepository<CurrentSensor>>(); var mockRepoCoordinates = new Mock<IDeletableEntityRepository<GeographicalCoordinates>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoCurrentSensor.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoCurrentSensor.Setup(x => x.AddAsync(It.IsAny<CurrentSensor>())).Callback((CurrentSensor currentSensor) => list.Add(currentSensor));

            var service = new CurrentSensorService(mockRepoCurrentSensor.Object, mockRepoImage.Object, mockRepoCoordinates.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new CurrentSensorInputModel
                {

                    Name = "test",
                    Image = file,
                };

                await service.CreateAsync(inputModel, 2, "23");
                await service.CreateAsync(inputModel, 3, "213");
                
                var count = service.GetAll<T>().Count();

                Assert.Equal(2, count);
            }
        }

        [Fact]
        public void GetByIdWorkCorrecllyCurrentSensorModel()
        {
            var model = this.TestGetByIdWorkCorrectllyCurrentSensorModel<CurrentSensorViewModel>();
            Assert.NotNull(model);
        }

        public async Task<T> TestGetByIdWorkCorrectllyCurrentSensorModel<T>()
        {
            var list = new List<CurrentSensor>();
            var mockRepoCurrentSensor = new Mock<IDeletableEntityRepository<CurrentSensor>>(); var mockRepoCoordinates = new Mock<IDeletableEntityRepository<GeographicalCoordinates>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoCurrentSensor.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoCurrentSensor.Setup(x => x.AddAsync(It.IsAny<CurrentSensor>())).Callback((CurrentSensor currentSensor) => list.Add(currentSensor));

            var service = new CurrentSensorService(mockRepoCurrentSensor.Object, mockRepoImage.Object, mockRepoCoordinates.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new CurrentSensorInputModel
                {

                    Name = "test",
                    Image = file,
                };

                await service.CreateAsync(inputModel, 2, "23");
                await service.CreateAsync(inputModel, 3, "213");

                var model = service.GetById<T>(0);

                return model;
            }
        }
    }
}
