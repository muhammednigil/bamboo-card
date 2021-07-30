using BambooDomain.Requests;
using BambooDomain.Responses;
using BambooService;
using BambooService.Interface;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BambooUnitTest.Services
{
    public class ServiceTest : ServiceTestBase<Service>
    {
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly Mock<IHttpService> _mockHttpService;
        private readonly IService _service;
        public ServiceTest()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockHttpService = new Mock<IHttpService>();

            _service = new Service(_mockConfiguration.Object, _mockHttpService.Object);
        }

        [Fact]
        public void GetCatalogs_ShouldReturnList()
        {
            _mockConfiguration.Setup(x => x.GetSection(It.IsAny<string>())).Returns(new Mock<IConfigurationSection>().Object);

            _mockHttpService.Setup(x => x.GetAsync<CatalogResponse>(It.IsAny<string>())).Returns(Task.FromResult(MockData.CatalogResponse()));

            var result = _service.GetCatalogs().Result;

            Assert.NotNull(result.Brands);
            Assert.True(result.Brands.Count > 0);
        }

        [Fact]
        public void GetCatalogs_ShouldReturnEmptyList()
        {
            _mockConfiguration.Setup(x => x.GetSection(It.IsAny<string>())).Returns(new Mock<IConfigurationSection>().Object);

            _mockHttpService.Setup(x => x.GetAsync<CatalogResponse>(It.IsAny<string>())).Returns(Task.FromResult(new CatalogResponse()));

            var result = _service.GetCatalogs().Result;

            Assert.Null(result.Brands);
        }

        [Fact]
        public void GetAccounts_ShouldReturnList()
        {
            _mockConfiguration.Setup(x => x.GetSection(It.IsAny<string>())).Returns(new Mock<IConfigurationSection>().Object);

            _mockHttpService.Setup(x => x.GetAsync<AccountResponse>(It.IsAny<string>())).Returns(Task.FromResult(MockData.AccountResponse()));

            var result = _service.GetAccounts().Result;

            Assert.NotNull(result.Accounts);
            Assert.True(result.Accounts.Count > 0);
        }

        [Fact]
        public void GetAccounts_ShouldReturnEmptyList()
        {
            _mockConfiguration.Setup(x => x.GetSection(It.IsAny<string>())).Returns(new Mock<IConfigurationSection>().Object);

            _mockHttpService.Setup(x => x.GetAsync<AccountResponse>(It.IsAny<string>())).Returns(Task.FromResult(new AccountResponse()));

            var result = _service.GetAccounts().Result;

            Assert.Null(result.Accounts);
        }

        [Theory]
        [InlineData("ae05a22b-e995-49fa-9826-998ff8176a51")]
        public void GetOrderDetails_ShouldReturnData(string requestId)
        {
            _mockConfiguration.Setup(x => x.GetSection(It.IsAny<string>())).Returns(new Mock<IConfigurationSection>().Object);

            _mockHttpService.Setup(x => x.GetAsync<OrderDetailResponse>(It.IsAny<string>())).Returns(Task.FromResult(MockData.OrderDetailResponse(requestId)));

            var result = _service.GetOrderDetails(requestId).Result;

            Assert.NotNull(result.RequestId);
            Assert.Equal(requestId, result.RequestId);
        }

        [Theory]
        [InlineData("")]
        [InlineData("ae05a22b-e995-49fa-9826-998ff8176a51s")]
        public void GetOrderDetails_ShouldReturnErrorData(string requestId)
        {
            _mockConfiguration.Setup(x => x.GetSection(It.IsAny<string>())).Returns(new Mock<IConfigurationSection>().Object);

            _mockHttpService.Setup(x => x.GetAsync<OrderDetailResponse>(It.IsAny<string>())).Returns(Task.FromResult(MockData.OrderDetailResponse(requestId)));

            var result = _service.GetOrderDetails(requestId).Result;

            Assert.Equal("400", result.Status);
        }

        [Fact]
        public void SaveOrder_ShouldReturnValidReponse()
        {
            var request = new OrderRequest
            {
                RequestId = Guid.NewGuid().ToString(),
                AccountId = 3131,
                Products = new List<Product>
                {
                    new Product
                    {
                        ProductId = 62373,
                        Quantity = 1,
                        Value = 50.0
                    }
                }
            };

            _mockConfiguration.Setup(x => x.GetSection(It.IsAny<string>())).Returns(new Mock<IConfigurationSection>().Object);

            _mockHttpService.Setup(x => x.PostAsync<string>(It.IsAny<string>(), It.IsAny<object>())).Returns(Task.FromResult(MockData.OrderResponse(request)));

            var result = _service.SaveOrders(request).Result;

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData(0, 62373, 50)]
        [InlineData(3131, 0, 50)]
        [InlineData(3131, 62373, 522)]
        public void SaveOrder_ShouldReturnInValidReponse(long accountId, long productId, double value)
        {
            var request = new OrderRequest
            {
                AccountId = accountId,
                Products = new List<Product>
                {
                    new Product
                    {
                        ProductId = productId,
                        Quantity = 1,
                        Value = value
                    }
                }
            };

            _mockConfiguration.Setup(x => x.GetSection(It.IsAny<string>())).Returns(new Mock<IConfigurationSection>().Object);

            _mockHttpService.Setup(x => x.PostAsync<OrderResponse>(It.IsAny<string>(), It.IsAny<object>())).Returns(Task.FromResult(new OrderResponse()));

            var result = _service.SaveOrders(request).Result;

            Assert.Null(result);
        }
    }
}
