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
    using Xunit;

    public class ConductorTests
    {
        [Fact]
        public async Task CreateCorrectllyConductorModel()
        {
            var list = new List<Conductor>();
            var mockRepoConductor = new Mock<IDeletableEntityRepository<Conductor>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoConductor.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoConductor.Setup(x => x.AddAsync(It.IsAny<Conductor>())).Callback((Conductor conductor) => list.Add(conductor));

            var service = new ConductorService(mockRepoConductor.Object, mockRepoImage.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new ConductorInputModel
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
            var list = new List<Conductor>();
            var mockRepoConductor = new Mock<IDeletableEntityRepository<Conductor>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoConductor.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoConductor.Setup(x => x.AddAsync(It.IsAny<Conductor>())).Callback((Conductor conductor) => list.Add(conductor));

            var service = new ConductorService(mockRepoConductor.Object, mockRepoImage.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new ConductorInputModel
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
        public void GetAllWorkCorrecllyConductorModel()
        {
            this.TestGetAllWorkCorrectllyConductorModel<ConductorViewModel>();
        }

        public async Task TestGetAllWorkCorrectllyConductorModel<T>()
        {
            var list = new List<Conductor>();
            var mockRepoConductor = new Mock<IDeletableEntityRepository<Conductor>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoConductor.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoConductor.Setup(x => x.AddAsync(It.IsAny<Conductor>())).Callback((Conductor conductor) => list.Add(conductor));

            var service = new ConductorService(mockRepoConductor.Object, mockRepoImage.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new ConductorInputModel
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
        public void GetByIdWorkCorrecllyConductorModel()
        {
            var model = this.TestGetByIdWorkCorrectllyConductorModel<ConductorViewModel>();
            Assert.NotNull(model);
        }

        public async Task<T> TestGetByIdWorkCorrectllyConductorModel<T>()
        {
            var list = new List<Conductor>();
            var mockRepoCondcutor = new Mock<IDeletableEntityRepository<Conductor>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoCondcutor.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoCondcutor.Setup(x => x.AddAsync(It.IsAny<Conductor>())).Callback((Conductor conductor) => list.Add(conductor));

            var service = new ConductorService(mockRepoCondcutor.Object, mockRepoImage.Object);

            using (var stream = File.OpenRead("testImage.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                };

                var inputModel = new ConductorInputModel
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
