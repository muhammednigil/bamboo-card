using System;
using System.Collections.Generic;
using System.Text;

namespace BambooDomain.DTO
{
    public class CardDTO
    {
        public string SerialNumber { get; set; }
        public string CardCode { get; set; }
        public string Url { get; set; }
        public string Pin { get; set; }
        public string ExpirationDate { get; set; }
    }
}
