using System.Data;
using Customer_Service.Application.Interfaces;
using Customer_Service.DTO.Customer;
using Customer_Service.Entities;
using Customer_Service.Infrastructure.Helpers;
using Dapper;

namespace Customer_Service.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly IDbConnectFactory _connectFactory;

    public CustomerRepository(IDbConnectFactory configuration)
    {
        _connectFactory = configuration;
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        var sql = $@" 
            SELECT c.*, ct.*
            From Customer c
            LEFT JOIN City ct ON c.CityId=ct.Id 
            WHERE c.Id={id}
            ";
        using (var connection = _connectFactory.GetSqlConnection())
        {
            connection.Open();
            var result = await connection.QueryAsync<Customer, City, Customer>(
                sql,
                (customer, city) =>
                {
                    customer.City = city;
                    return customer;
                });

            return result.FirstOrDefault();
        }
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        var sql = @" 
            SELECT c.*, ct.*
            From Customer c
            LEFT JOIN City ct ON c.CityId=ct.Id";
        using (var connection = _connectFactory.GetSqlConnection())
        {
            connection.Open();
            return await connection.QueryAsync<Customer, City, Customer>(sql, (customer, city) =>
            {
                customer.City = city;
                return customer;
            });
        }
    }

    public async Task<Customer> AddAsync(Customer entity)
    {
        var sql =
            "Insert into Customer(Name,Surname,Email,PhoneNumber,CityId) values (@Name,@Surname,@Email,@PhoneNumber,@CityId)";
        using (var connection = _connectFactory.GetSqlConnection())
        {
            connection.Open();
            await connection.ExecuteAsync(sql, entity);
            return new Customer()
            {
                Name = entity.Name,
                Surname = entity.Surname,
                CityId = entity.CityId,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email
            };
        }
    }


    public async Task<Customer?> UpdateAsync(Customer entity)
    {
        var sql =
            $@"Update Customer SET Name= @Name,Email=@Email, Surname= @Surname,CityId=@CityId Where Id= @Id; 
            SELECT c.*, ct.*
            From Customer c
            LEFT JOIN City ct ON c.CityId=ct.Id  
            WHERE c.Id=@Id
";
        var parameters = new DynamicParameters();
        parameters.Add("@Name", entity.Name, DbType.String, ParameterDirection.Input);

        using (var connection = _connectFactory.GetSqlConnection())
        {
            connection.Open();
            IEnumerable<Customer> customer = await connection.QueryAsync<Customer, City, Customer>(sql,
                (customer, city) =>
                {
                    customer.City = city;
                    return customer;
                },
                new {Name=entity.Name,Email=entity.Email,Surname=entity.Surname,CityId=entity.CityId,Id=entity.Id}


            );
            return customer.FirstOrDefault();
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sql = $"DELETE FROM Customer WHERE Id= {id}";
        using (var connection = _connectFactory.GetSqlConnection())
        {
            connection.Open();
            try
            {
                await connection.ExecuteAsync(sql);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

    public async Task<Customer> RegisterAsync(RegisterCustomerRequestDto entity)
    {
        var sql =
            "Insert into Customer(Name,Surname,Email,PhoneNumber,CityId,PasswordHash) values (@Name,@Surname,@Email,@PhoneNumber,@CityId,@Password); Select*From Customer Where Id=SCOPE_IDENTITY()";
        using (var connection = _connectFactory.GetSqlConnection())
        {
            connection.Open();
            return await connection.QueryFirstAsync<Customer>(sql, entity);
        }
    }


    public async Task<Customer> GetCustomerByEmailAsync(string email)
    {
        var sql = $"SELECT * FROM Customer WHERE Email='{email}'";
        using (var connection = _connectFactory.GetSqlConnection())
        {
            connection.Open();
            return await connection.QueryFirstAsync<Customer>(sql);
        }
    }
}