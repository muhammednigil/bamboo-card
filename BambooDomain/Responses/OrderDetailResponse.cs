using BambooDomain.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BambooDomain.Responses
{
    public class OrderDetailResponse : OrderResponse
    {
        public long OrderId { get; set; }
        public List<Item>Items { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Total { get; set; }
        public List<FailureDTO> Failures { get; set; }
        public JObject Errors { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string TraceId { get; set; }

    }
    public class Item
    {
        public string BrandCode { get; set; }
        public long ProductId { get; set; }
        public double ProductFaceValue { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public string CountryCode { get; set; }
        public string CurrencyCode { get; set; }
        public List<CardDTO> Cards { get; set; }
        public List<FailureDTO> Failures { get; set; }
    }
}
