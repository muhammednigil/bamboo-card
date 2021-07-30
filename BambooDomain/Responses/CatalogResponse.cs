using BambooDomain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BambooDomain.Responses
{
    public class CatalogResponse
    {
        public List<BrandDTO> Brands { get; set; }
    }
}
