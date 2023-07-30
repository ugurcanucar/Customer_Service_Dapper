using System.Data.SqlClient;
using Customer_Service.Application.Interfaces;
using Customer_Service.DTO.City;
using Customer_Service.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Customer_Service.Infrastructure.Repositories;

public class CityRepository : ICityRepository
{
    private readonly IConfiguration _configuration;

    public CityRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<City> GetByIdAsync(int id)
    {
        var sql = $"SELECT * FROM City Where Id= {id}";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            connection.Open();
            return await connection.QuerySingleOrDefaultAsync<City>(sql);
        }
    }

    public async Task<IEnumerable<City>> GetAllAsync()
    {
        var sql = "SELECT*FROM City";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            connection.Open();
            return await connection.QueryAsync<City>(sql);
        }
    }

    public async Task<City> AddAsync(City entity)
    {
        var sql = $"INSERT INTO City(Name) VALUES('{entity.Name}'); Select*From City Where Id=SCOPE_IDENTITY()";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            connection.Open();
            var city = await connection.QueryFirstAsync<City>(sql);
            return city;
        }
    }


    public async Task<City> UpdateAsync(City entity)
    {
        var sql = $"Update City SET Name={entity.Name} Where Id= {entity.Id}; Select*From City Where Id={entity.Id}";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            connection.Open();
            return await connection.QueryFirstAsync<City>(sql, entity);
            
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sql = "Delete From City Where Id=@Id";
        using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            connection.Open();
            await connection.ExecuteAsync(sql, id);
            return true;
        }
    }
}