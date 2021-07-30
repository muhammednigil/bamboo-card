using BambooDomain.Requests;
using BambooDomain.Responses;
using BambooService.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BambooService
{
    public class Service : IService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpService _httpService;
        public Service(IConfiguration configuration, IHttpService httpService)
        {
            _configuration = configuration;
            _httpService = httpService;
        }

        public async Task<CatalogResponse> GetCatalogs()
        {
            var requestUri = $"{_configuration.GetValue<string>("ExternalApp:BaseUrl")}{_configuration.GetValue<string>("ExternalApp:GetCatalog")}";
            try
            {
                return await _httpService.GetAsync<CatalogResponse>(requestUri);
            }
            catch (Exception ex)
            {
                return new CatalogResponse();
            }
        }

        public async Task<AccountResponse> GetAccounts()
        {
            var requestUri = $"{_configuration.GetValue<string>("ExternalApp:BaseUrl")}{_configuration.GetValue<string>("ExternalApp:GetAccount")}";
            try
            {
                return await _httpService.GetAsync<AccountResponse>(requestUri);
            }
            catch (Exception)
            {
                return new AccountResponse();
            }
        }

        public async Task<OrderDetailResponse> GetOrderDetails(string requestId)
        {
            var requestUri = $"{_configuration.GetValue<string>("ExternalApp:BaseUrl")}{_configuration.GetValue<string>("ExternalApp:GetOrder")}";
            requestUri.Replace("{requestId}", requestId);
            try
            {
                return await _httpService.GetAsync<OrderDetailResponse>(requestUri);
            }
            catch (Exception)
            {
                return new OrderDetailResponse();
            }
        }

        public async Task<string> SaveOrders(OrderRequest orderRequest)
        {
            var requestUri = $"{_configuration.GetValue<string>("ExternalApp:BaseUrl")}{_configuration.GetValue<string>("ExternalApp:PostOrder")}";
            orderRequest.RequestId = Guid.NewGuid().ToString();
            try
            {
                //return await _httpService.PostAsync<OrderResponse>(requestUri, orderRequest);
                return await _httpService.PostAsync<string>(requestUri, orderRequest);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
