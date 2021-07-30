using BambooDomain.Requests;
using BambooDomain.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BambooService.Interface
{
    public interface IService
    {
        Task<CatalogResponse> GetCatalogs();
        Task<AccountResponse> GetAccounts();
        Task<OrderDetailResponse> GetOrderDetails(string requestId);
        Task<string> SaveOrders(OrderRequest orderRequest);
    }
}
