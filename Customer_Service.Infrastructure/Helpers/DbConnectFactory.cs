using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Customer_Service.Infrastructure.Helpers;

public class DbConnectFactory:IDbConnectFactory
{
    private readonly IConfiguration _configuration;

    public DbConnectFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public SqlConnection GetSqlConnection()
    {
        string connectionString = _configuration.GetConnectionString("DefaultConnection")??"";
        return new SqlConnection(connectionString);
    }
}