using System;

namespace MarketData.Query.Contracts
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
