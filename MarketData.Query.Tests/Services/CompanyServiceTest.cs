using Castle.Core.Logging;
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
        public void ShouldLogDebugWhenPingIsCalled()
        {
            var logSpy = Substitute.For<ILogger>();
            var companyQuery = Substitute.For<ICompanyQuery>();
            var mapper = Substitute.For<IMapper>();
            var companyService = new CompanyService(companyQuery, mapper ) { Logger = logSpy };

            var companies = companyService.GetCompanies().Result;

            logSpy.Received(1).Debug("CompanyService.GetCompanies called");
        }
    }
}
