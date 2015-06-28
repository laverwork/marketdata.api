using Castle.Core.Logging;
using MarketData.Query.Caching;
using MarketData.Query.Mappers;
using MarketData.Query.Queries;
using MarketData.Query.Services;
using NSubstitute;
using Xunit;

namespace MarketData.Query.Tests.Services
{
    public class CompanyServiceTest
    {
        [Fact]
        public void ShouldLogDebugWhenGetCompaniesIsCalled()
        {
            var logSpy = Substitute.For<ILogger>();
            var companyQuery = Substitute.For<ICompanyQuery>();

            var mapper = Substitute.For<IMapper>();
            var cache = Substitute.For<ICache>();
            var companyService = new CompanyService(companyQuery, mapper, cache) { Logger = logSpy };

            var companies = companyService.GetCompanies().Result;

            logSpy.Received(1).Debug("CompanyService.GetCompanies called");
        }

        [Fact]
        public void ShouldCacheGetCompanies()
        {
            var logSpy = Substitute.For<ILogger>();          
            var companyQuery = Substitute.For<ICompanyQuery>();


            var mapper = Substitute.For<IMapper>();
            var cache = new InMemoryCache();
            var companyService = new CompanyService(companyQuery, mapper, cache) { Logger = logSpy };

            companyService.GetCompanies();
            companyService.GetCompanies();
            companyService.GetCompanies();
            companyService.GetCompanies();
            companyService.GetCompanies();

            companyQuery.Received(1).GetCompanies();        
        }
    }
}
