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
    public class AccountControllerTest
    {
        [Fact]
        public async Task ShouldReturnOkValidAccounts()
        {
            var mockService = new Mock<IService>();
            var accountController = new AccountController(mockService.Object);

            var response = await accountController.GetAccounts();

            Assert.IsType<OkObjectResult>(response);

        }

        [Fact]
        public async Task ShouldReturnBadRequestAccounts()
        {

            var mockService = new Mock<IService>();
            var accountController = new AccountController(mockService.Object);
            mockService.Setup(x => x.GetAccounts()).Throws(new Exception());

            var response = await accountController.GetAccounts();

            Assert.IsType<BadRequestObjectResult>(response);
        }
    }
}
