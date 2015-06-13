namespace MarketData.Query.Mappers
{
    public class Mappers
    {
        public static void Init()
        {
            AutoMapper.Mapper.AddProfile<CompanyMappingProfile>();
        }
    }
}
