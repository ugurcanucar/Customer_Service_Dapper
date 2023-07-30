using System.Data.SqlClient;

namespace Customer_Service.Infrastructure.Helpers;

public interface IDbConnectFactory
{
    SqlConnection GetSqlConnection();
}