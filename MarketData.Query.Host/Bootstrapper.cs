using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MarketData.Query.Mappers;
using MarketData.Query.Queries;
using MarketData.Query.Services;
using Nancy.Bootstrappers.Windsor;

namespace MarketData.Query.Host
{
    public class Bootstrapper : WindsorNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.AddFacility<LoggingFacility>(x => x.LogUsing(LoggerImplementation.Log4net).WithConfig("log4net.config"));

            Mappers.Mappers.Init();

            container.Register(Component.For<IMapper>()
               .ImplementedBy<Mapper>()
               .LifestyleSingleton());


            container.Register(Component.For<ICompanyQuery>().ImplementedBy<CompanyQuery>());
            container.Register(Component.For<ICompanyService>().ImplementedBy<CompanyService>());

            container.Register(Component.For<IPingService>().ImplementedBy<PingService>());

        }
    }
}