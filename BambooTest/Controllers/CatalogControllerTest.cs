using Bamboo.Controllers;
using BambooService.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BambooUnitTest.Controllers
{
    public class CatalogControllerTest
    {
        [Fact]
        public async Task ShouldReturnOkValidCatalogs()
        {
            var mockService = new Mock<IService>();
            var catalogController = new CatalogController(mockService.Object);

            var response = await catalogController.GetCatalogs();

            Assert.IsType<OkObjectResult>(response);

        }

        [Fact]
        public async Task ShouldReturnBadRequestCatalogs()
        {

            var mockService = new Mock<IService>();
            var catalogController = new CatalogController(mockService.Object);
            mockService.Setup(x => x.GetCatalogs()).Throws(new Exception());

            var response = await catalogController.GetCatalogs();

            Assert.IsType<BadRequestObjectResult>(response);
        }
    }
}
