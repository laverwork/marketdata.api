using System.Threading.Tasks;
using MarketData.Query.Contracts;

namespace MarketData.Query.Services
{
    public interface ICompanyService
    {
        Task<GetCompaniesResponse> GetCompanies();
    }
}
