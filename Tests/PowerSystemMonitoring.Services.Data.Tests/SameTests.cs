namespace PowerSystemMonitoring.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Moq;
    using PowerSystemMonitoring.Data.Common.Repositories;
    using PowerSystemMonitoring.Data.Models;
    using PowerSystemMonitoring.Web.ViewModels.Area;
    using Xunit;

    public class SameTests
    {
        [Fact]
        public async Task AlabalaTest()
        {
            var list = new List<Area>();
            var mockRepoArea= new Mock<IDeletableEntityRepository<Area>>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();

            mockRepoArea.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepoArea.Setup(x => x.AddAsync(It.IsAny<Area>())).Callback((Area area) => list.Add(area));

            var service = new AreaService(mockRepoArea.Object, mockRepoImage.Object);

            var inputModel = new AreaInputModel
            {
                Name = "test",
            };

            service.CreateAsync(inputModel, "23");
            service.CreateAsync(inputModel, "13");

            Assert.Equal(2, list.Count);
          


        }
    }

    

    
}
