using System;
using System.Collections.Generic;
using System.Text;

namespace BambooDomain.Requests
{
    public class OrderRequest
    {
        public string RequestId { get; set; }
        public long AccountId { get; set; }
        public List<Product> Products { get; set; }
    }
    public class Product
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }
    }
}
