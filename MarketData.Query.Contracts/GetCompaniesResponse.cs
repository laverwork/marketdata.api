using System.Collections.Generic;

namespace MarketData.Query.Contracts
{
    public class GetCompaniesResponse
    {
        public IEnumerable<Company> Companies { get; set; } 
    }
}
