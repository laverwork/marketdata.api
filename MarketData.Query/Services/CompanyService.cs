using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Logging;
using MarketData.Query.Contracts;
using MarketData.Query.Mappers;
using MarketData.Query.Queries;

namespace MarketData.Query.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyQuery _companyQuery;
        private readonly IMapper _mapper;

        private ILogger _logger = NullLogger.Instance;

        public ILogger Logger
        {
            get { return _logger; }
            set { _logger = value; }
        }

        public CompanyService(ICompanyQuery companyQuery, IMapper mapper)
        {
            _companyQuery = companyQuery;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            _logger.Debug("CompanyService.GetCompanies called");
            var companies = await _companyQuery.GetCompanies();
            var companyList = companies.Select(x => _mapper.Map<CompanyDto, Company>(x));
            return companyList;
        }
    }
}