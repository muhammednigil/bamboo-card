using System;
using System.Collections.Generic;
using System.Text;

namespace BambooDomain.DTO
{
    public class AccountDTO
    {
        public long Id { get; set; }
        public string Currency { get; set; }
        public double Balance { get; set; }
        public bool IsActive { get; set; }
    }
}


