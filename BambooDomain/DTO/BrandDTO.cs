using System;
using System.Collections.Generic;
using System.Text;

namespace BambooDomain.DTO
{
    public class BrandDTO
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string CurrencyCode { get; set; }
        public string Description { get; set; }
        public string Disclaimer { get; set; }
        public string RedemptionInstructions { get; set; }
        public string Terms { get; set; }
        public string LogoUrl { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
