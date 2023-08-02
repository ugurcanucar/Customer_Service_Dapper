using System.Data.SqlClient;
using Customer_Service.Application.Interfaces;
using Customer_Service.DTO.City;
using Customer_Service.Entities;
using Customer_Service.Infrastructure.Helpers;
using Dapper;
using Microsoft.Extensions.Configuration;
using DbConnection = System.Data.Common.DbConnection;

namespace Customer_Service.Infrastructure.Repositories;

public class CityRepository : ICityRepository
{
    private readonly IDbConnectFactory _connectFactory;

    public CityRepository(IDbConnectFactory dbConnectFactory)
    {
        _connectFactory = dbConnectFactory;
    }

    public async Task<City?> GetByIdAsync(int id)
    {
        var sql = $"SELECT * FROM City Where Id={id}";
        using (var connection = _connectFactory.GetSqlConnection())
        {
            connection.Open();
            return await connection.QuerySingleOrDefaultAsync<City?>(sql);
        }
    }

    public async Task<IEnumerable<City>> GetAllAsync()
    {
        var sql = "SELECT*FROM City";
        using (var connection = _connectFactory.GetSqlConnection())
        {
            connection.Open();
            return await connection.QueryAsync<City>(sql);
        }
    }

    public async Task<City> AddAsync(City entity)
    {
        var sql = $"INSERT INTO City(Name) VALUES('{entity.Name}'); Select*From City Where Id=SCOPE_IDENTITY()";
        using (var connection = _connectFactory.GetSqlConnection())
        {
            connection.Open();
            var city = await connection.QueryFirstAsync<City>(sql);
            return city;
        }
    }


    public async Task<City?> UpdateAsync(City entity)
    {
        var sql = $"Update City SET Name=@Name Where Id=@Id; Select*From City Where Id=@Id";
        using (var connection = _connectFactory.GetSqlConnection())
        {
            connection.Open();
            return await connection.QuerySingleOrDefaultAsync<City?>(sql, entity);
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sql = "Delete From City Where Id=" + id;
        using (var connection = _connectFactory.GetSqlConnection())
        {
            connection.Open();
            return await connection.ExecuteAsync(sql, id) > 0;
        }
    }
}