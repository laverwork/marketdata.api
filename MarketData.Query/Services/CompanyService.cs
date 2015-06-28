using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Logging;
using MarketData.Query.Caching;
using MarketData.Query.Contracts;
using MarketData.Query.Mappers;
using MarketData.Query.Queries;

namespace MarketData.Query.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyQuery _companyQuery;
        private readonly IMapper _mapper;
        private readonly ICache _cache;
        static private readonly object CacheLock = new object();
        private const int CacheMinutes = 10;
        private const string CacheKey = "companies";
        private ILogger _logger = NullLogger.Instance;

        public ILogger Logger
        {
            get { return _logger; }
            set { _logger = value; }
        }

        public CompanyService(ICompanyQuery companyQuery, IMapper mapper, ICache cache)
        {
            _companyQuery = companyQuery;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<GetCompaniesResponse> GetCompanies()
        {
            _logger.Debug("CompanyService.GetCompanies called");

            var companiesDtos = await Task.Run(() =>
                _cache.RetreiveFromCache(CacheLock, CacheKey, DateTime.Now.AddMinutes(CacheMinutes),
                    () => _companyQuery.GetCompanies()));

            return new GetCompaniesResponse
            {
                Companies = companiesDtos.Select(x => _mapper.Map<CompanyDto, Company>(x))
            };
            //var companyList = companies.Select(x => _mapper.Map<CompanyDto, Company>(x));
            //return companyList;
        }
    }
}