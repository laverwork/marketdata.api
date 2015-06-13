using System.Collections.Generic;
using System.Threading.Tasks;
using MarketData.Query.Contracts;

namespace MarketData.Query.Queries
{
    public interface ICompanyQuery
    {
        Task<IEnumerable<CompanyDto>> GetCompanies();
    }
}
