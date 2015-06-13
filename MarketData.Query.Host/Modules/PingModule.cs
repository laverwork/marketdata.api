using MarketData.Query.Services;
using Nancy;

namespace MarketData.Query.Host.Modules
{
    public class PingModule : NancyModule
    {
        private readonly IPingService _pingService;

        public PingModule(IPingService pingService)
        {
            _pingService = pingService;

            Get["/ping"] = _ => _pingService.Ping();
        }
    }
}