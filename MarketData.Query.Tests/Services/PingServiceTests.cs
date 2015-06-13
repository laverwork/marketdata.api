using Castle.Core.Logging;
using MarketData.Query.Services;
using NSubstitute;
using Should;
using Xunit;

namespace MarketData.Query.Tests.Services
{
    public class PingServiceTests
    {
        [Fact]
        public void ShouldReturnPongWhenPingIsCalled()
        {
            var pingService = new PingService();
            pingService.Ping().ShouldEqual("pong");
        }

        [Fact]
        public void ShouldLogDebugWhenPingIsCalled()
        {
            var logSpy = Substitute.For<ILogger>();
            var pingService = new PingService {Logger = logSpy};

            pingService.Ping();

            logSpy.Received(1).Debug("PingService.Ping called");
        }
    }
}
