using MarketData.Query.Services;
using Nancy;

namespace MarketData.Query.Host.Modules
{
    public class CompanyModule : NancyModule
    {
        private readonly ICompanyService _companyService;

        public CompanyModule(ICompanyService companyService)
        {
            _companyService = companyService;

            Get["/companies", runAsync: true] =
                async (_, token) => Response.AsJson(await _companyService.GetCompanies());
        }
    }
}