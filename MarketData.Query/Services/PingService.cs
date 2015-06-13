using Castle.Core.Logging;

namespace MarketData.Query.Services
{
    public class PingService : IPingService
    {
        private const string Pong = "pong";

        private ILogger _logger = NullLogger.Instance;

        public ILogger Logger
        {
            get { return _logger; }
            set { _logger = value; }
        }

        public string Ping()
        {
            _logger.Debug("PingService.Ping called");
            return Pong;
        }
    }
}