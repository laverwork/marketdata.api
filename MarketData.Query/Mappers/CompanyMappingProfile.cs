using AutoMapper;
using MarketData.Query.Contracts;

namespace MarketData.Query.Mappers
{
    class CompanyMappingProfile  : Profile
    {
        protected override void Configure()
        {
            AutoMapper.Mapper.CreateMap<CompanyDto, Company>();
        }
    }
}
