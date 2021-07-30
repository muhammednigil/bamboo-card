using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BambooService.Interface
{
    public interface IHttpService
    {
        Task<T> GetAsync<T>(string requestUri);
        Task<T> PostAsync<T>(string requestUri, object data);
    }
}
