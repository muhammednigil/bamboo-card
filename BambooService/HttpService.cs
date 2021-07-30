using BambooService.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BambooService
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public HttpService(
            IConfiguration configuration,
            HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;

            var credentials = $"{_configuration.GetValue<string>("ExternalApp:ClientId")}:{_configuration.GetValue<string>("ExternalApp:ClientSecret")}";
            var bytes = credentials.EncodeToBase64();

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", bytes);

            _httpClient.Timeout = TimeSpan.FromSeconds(_configuration.GetValue<int>("App:MaxHttpClientTimeout"));
        }

        public async Task<T> GetAsync<T>(string requestUri)
        {
            return await GetAsync<T>(HttpCompletionOption.ResponseContentRead, new Uri(requestUri));
        }

        public async Task<T> GetAsync<T>(HttpCompletionOption completionOption, Uri requestUri, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await _httpClient.GetAsync(requestUri, completionOption, cancellationToken);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return content.ToObject<T>();
        }

        public async Task<T> PostAsync<T>(string requestUri, object data)
        {
            HttpContent content = data?.ToJsonStringContent();
            return await PostAsync<T>(content, new Uri(requestUri));
        }

        public async Task<T> PostAsync<T>(HttpContent content, Uri requestUri, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await _httpClient.PostAsync(requestUri, content, cancellationToken);
            var result = await response.Content.ReadAsStringAsync();
            return result.ToObject<T>();
        }
    }

    public static class Extensions
    {
        private static IsoDateTimeConverter dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-ddTHH:mm:ss" };
        public static T ToObject<T>(this string data)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(data, dateTimeConverter);
            }
            catch (Exception)
            {
                return JsonConvert.DeserializeObject<T>(data);
            }
        }
        public static StringContent ToJsonStringContent(this object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj, dateTimeConverter), Encoding.UTF8, "application/json");
        }
        public static string EncodeToBase64(this string data)
        {
            var dataBytes = Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(dataBytes);
        }
        public static JObject ToJObject(this string data)
        {
            try
            {
                return JsonConvert.DeserializeObject<JObject>(data, dateTimeConverter);
            }
            catch (Exception)
            {
                return JsonConvert.DeserializeObject<JObject>(data);
            }
        }
    }
}
