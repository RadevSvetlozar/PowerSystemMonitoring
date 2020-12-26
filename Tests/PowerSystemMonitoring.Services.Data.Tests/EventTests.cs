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
    using PowerSystemMonitoring.Web.ViewModels.Event;
    using Xunit;

    public class EventTests
    {
        [Fact]
        public async Task CreateCorrectllyEventModel()
        {
            var list = new List<Event>();
            var mockRepoEvent = new Mock<IDeletableEntityRepository<Event>>();

            mockRepoEvent.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoEvent.Setup(x => x.AddAsync(It.IsAny<Event>())).Callback((Event @event) => list.Add(@event));

            var service = new EventService(mockRepoEvent.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new EventInputModel
                {

                    Name = "test",
                };

                await service.CreateAsync(inputModel, "23");
                await service.CreateAsync(inputModel, "213");

                Assert.Equal(2, list.Count);
            }
        }

        [Fact]
        public async Task DeleteCorrectllyEventModel()
        {
            var list = new List<Event>();
            var mockRepoEvent = new Mock<IDeletableEntityRepository<Event>>();

            mockRepoEvent.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoEvent.Setup(x => x.Delete(It.IsAny<Event>())).Callback((Event @event) => list.Remove(@event));

            var service = new EventService(mockRepoEvent.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new EventInputModel
                {

                    Name = "test",
                };

                await service.CreateAsync(inputModel, "23");
                await service.CreateAsync(inputModel, "213");

                await service.DeleteAsync(0);

                Assert.Equal(0, list.Count);
            }
        }

        [Fact]
        public void GetAllWorkCorrecllyEventModel()
        {
            this.TestGetAllWorkCorrectllyEventModel<EventViewModel>();
        }

        public async Task TestGetAllWorkCorrectllyEventModel<T>()
        {
            var list = new List<Event>();
            var mockRepoEvent = new Mock<IDeletableEntityRepository<Event>>();

            mockRepoEvent.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoEvent.Setup(x => x.AddAsync(It.IsAny<Event>())).Callback((Event @event) => list.Add(@event));

            var service = new EventService(mockRepoEvent.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new EventInputModel
                {

                    Name = "test",
                };

                await service.CreateAsync(inputModel, "23");
                await service.CreateAsync(inputModel, "213");

                var count = service.GetAll<T>().Count();

                Assert.Equal(2, count);
            }
        }

        [Fact]
        public void GetByIdWorkCorrecllyEventModel()
        {
            var model = this.TestGetByIdWorkCorrectllyEventModel<EventViewModel>();
            Assert.NotNull(model);
        }

        public async Task<T> TestGetByIdWorkCorrectllyEventModel<T>()
        {
            var list = new List<Event>();
            var mockRepoEvent = new Mock<IDeletableEntityRepository<Event>>();

            mockRepoEvent.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoEvent.Setup(x => x.AddAsync(It.IsAny<Event>())).Callback((Event @event) => list.Add(@event));

            var service = new EventService(mockRepoEvent.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new EventInputModel
                {

                    Name = "test",
                };

                await service.CreateAsync(inputModel, "23");
                await service.CreateAsync(inputModel, "213");

                var model = service.GetById<T>(0);

                return model;
            }
        }
    }
}
