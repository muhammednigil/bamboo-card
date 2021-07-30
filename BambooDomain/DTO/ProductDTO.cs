using System;
using System.Collections.Generic;
using System.Text;

namespace BambooDomain.DTO
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double MinFaceValue { get; set; }
        public double MaxFaceValue { get; set; }
        public int? Count { get; set; }
        public PriceDTO Price { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
