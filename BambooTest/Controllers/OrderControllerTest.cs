using Bamboo.Controllers;
using BambooDomain.Requests;
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
    public class OrderControllerTest
    {
        [Fact]
        public async Task ShouldReturnOkValidOrders()
        {
            var mockService = new Mock<IService>();
            var orderController = new OrderController(mockService.Object);

            var response = await orderController.GetOrderDetails("ae05a22b-e995-49fa-9826-998ff8176a53");

            Assert.IsType<OkObjectResult>(response);

        }

        [Fact]
        public async Task ShouldReturnBadRequestOrders()
        {

            var mockService = new Mock<IService>();
            var orderController = new OrderController(mockService.Object);
            mockService.Setup(x => x.GetOrderDetails(It.IsAny<string>())).Throws(new Exception());

            var response = await orderController.GetOrderDetails("ae05a22b-e995-49fa-9826-998ff8176a53a");

            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public async Task ShouldReturnOkSaveValidOrders()
        {
            var mockService = new Mock<IService>();
            var orderController = new OrderController(mockService.Object);

            var response = await orderController.SaveOrder(new OrderRequest());

            Assert.IsType<OkObjectResult>(response);

        }

        [Fact]
        public async Task ShouldReturnBadRequestSaveOrders()
        {

            var mockService = new Mock<IService>();
            var orderController = new OrderController(mockService.Object);
            mockService.Setup(x => x.SaveOrders(It.IsAny<OrderRequest>())).Throws(new Exception());

            var response = await orderController.SaveOrder(new OrderRequest());

            Assert.IsType<BadRequestObjectResult>(response);
        }
    }
}
