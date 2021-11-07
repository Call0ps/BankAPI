using System;

namespace BankAPI.Models
{
    public record Account
    {
        public Guid Guid { get; set; }
        public double Balance {get; set; }
        public double Interest { get; set; }
    };
}

