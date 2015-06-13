using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using MarketData.Query.Contracts;

namespace MarketData.Query.Queries
{
    public class CompanyQuery : ICompanyQuery
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public async Task<IEnumerable<CompanyDto>> GetCompanies()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                return await connection.QueryAsync<CompanyDto>("SELECT Id, Name, Code FROM Company");  
            }
        }
    }
}