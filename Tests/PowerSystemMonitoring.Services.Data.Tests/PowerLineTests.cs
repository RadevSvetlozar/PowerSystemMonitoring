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
    using PowerSystemMonitoring.Web.ViewModels.PoweLine;
    using Xunit;

    public class PowerLineTests
    {
        [Fact]
        public async Task CreateCorrectllyPowerLineModel()
        {
            var list = new List<PowerLine>();
            var mockRepoPowerLine = new Mock<IDeletableEntityRepository<PowerLine>>(); var mockRepoCurrentSensor = new Mock<IDeletableEntityRepository<CurrentSensor>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoPowerLine.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoPowerLine.Setup(x => x.AddAsync(It.IsAny<PowerLine>())).Callback((PowerLine line) => list.Add(line));

            var service = new PowerLineService(mockRepoPowerLine.Object, mockRepoCurrentSensor.Object, mockRepoImage.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new PowerLineInputModel
                {

                    Name = "test",
                    Image = file,
                };

                await service.CreateAsync(inputModel, "23");

                Assert.Equal(1, list.Count);
            }
        }

        [Fact]
        public async Task DeleteCorrectllyConductorModel()
        {
            var list = new List<PowerLine>();
            var mockRepoPowerLine = new Mock<IDeletableEntityRepository<PowerLine>>();
            var mockRepoCurrentSensor = new Mock<IDeletableEntityRepository<CurrentSensor>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoPowerLine.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoPowerLine.Setup(x => x.Delete(It.IsAny<PowerLine>())).Callback((PowerLine line) => list.Remove(line));

            var service = new PowerLineService(mockRepoPowerLine.Object, mockRepoCurrentSensor.Object, mockRepoImage.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new PowerLineInputModel
                {

                    Name = "test",
                    Image = file,
                };

                await service.CreateAsync(inputModel, "23");
                await service.CreateAsync(inputModel, "13");

                await service.DeleteAsync(0);

                Assert.Equal(0, list.Count);
            }
        }

        [Fact]
        public void GetAllWorkCorrecllyPowerLineModel()
        {
            this.TestGetAllWorkCorrectllyPowerLineModel<PowerLine>();
        }

        public async Task TestGetAllWorkCorrectllyPowerLineModel<T>()
        {
            var list = new List<PowerLine>();
            var mockRepoPowerLine = new Mock<IDeletableEntityRepository<PowerLine>>(); var mockRepoCurrentSensor = new Mock<IDeletableEntityRepository<CurrentSensor>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoPowerLine.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoPowerLine.Setup(x => x.AddAsync(It.IsAny<PowerLine>())).Callback((PowerLine line) => list.Add(line));

            var service = new PowerLineService(mockRepoPowerLine.Object, mockRepoCurrentSensor.Object, mockRepoImage.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new PowerLineInputModel
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
        public void GetByIdWorkCorrecllyPowerLineModel()
        {
            var model = this.TestGetByIdWorkCorrectllyPowerLineModel<PowerLine>();
            Assert.NotNull(model);
        }

        public async Task<T> TestGetByIdWorkCorrectllyPowerLineModel<T>()
        {
            var list = new List<PowerLine>();
            var mockRepoPowerLine = new Mock<IDeletableEntityRepository<PowerLine>>(); var mockRepoCurrentSensor = new Mock<IDeletableEntityRepository<CurrentSensor>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoPowerLine.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoPowerLine.Setup(x => x.AddAsync(It.IsAny<PowerLine>())).Callback((PowerLine line) => list.Add(line));

            var service = new PowerLineService(mockRepoPowerLine.Object, mockRepoCurrentSensor.Object, mockRepoImage.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new PowerLineInputModel
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
